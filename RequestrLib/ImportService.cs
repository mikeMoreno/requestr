using Requestr.DAL;
using Requestr.Lib.Exceptions;
using Requestr.PostmanImporter;
using Requestr.PostmanImporter.Exceptions;
using Requestr.PostmanImporter.Models;

namespace Requestr.Lib
{
    public class ImportService
    {
        private readonly RequestrDbContext requestrDbContext;
        private readonly RequestImporter postmanImporter;

        public ImportService(RequestrDbContext requestrDbContext, RequestImporter postmanImporter)
        {
            this.requestrDbContext = requestrDbContext;
            this.postmanImporter = postmanImporter;
        }

        public async Task<Models.Collection> ImportAsync(string fileContents)
        {
            Collection postmanCollection;

            try
            {
                postmanCollection = postmanImporter.Import(fileContents);
            }
            catch (UnsupportedCollectionFormatVersionException e)
            {
                throw new ImportException(e.Message);
            }

            var collection = new Models.Collection()
            {
                Id = Guid.NewGuid(),
                Name = postmanCollection.Info.Name,
            };

            foreach (var requestItem in postmanCollection.Item)
            {
                collection.Requests.Add(new Models.Request()
                {
                    Id = Guid.NewGuid(),
                    Name = requestItem.Name,
                    Method = requestItem.Request.Method,
                    Url = requestItem.Request.Url.Raw,
                });
            }

            var dalCollection = new DAL.Models.RequestCollection()
            {
                Name = collection.Name,
                Requests = collection.Requests.Select(r => new DAL.Models.Request()
                {
                    Name = r.Name,
                    Method = r.Method,
                    Url = r.Url,
                }).ToList()
            };

            await requestrDbContext.RequestCollections.AddAsync(dalCollection);

            await requestrDbContext.SaveChangesAsync();

            return collection;
        }
    }
}