using Requestr.DAL;
using Requestr.DAL.Models;
using Requestr.Lib.Exceptions;
using Requestr.Lib.Models;
using Requestr.PostmanImporter;
using Requestr.PostmanImporter.Exceptions;

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

        public async Task<Collection> ImportAsync(string fileContents)
        {
            PostmanImporter.Models.Collection postmanCollection;

            try
            {
                postmanCollection = postmanImporter.Import(fileContents);
            }
            catch (UnsupportedCollectionFormatVersionException e)
            {
                throw new ImportException(e.Message);
            }

            var collection = MapFromPostman(postmanCollection);

            var dalCollection = new RequestCollection()
            {
                Id = collection.Id,
                Name = collection.Name,
                Requests = collection.Requests.Select(r => new DAL.Models.Request()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Method = r.Method,
                    Url = r.Url,
                }).ToList()
            };

            await requestrDbContext.RequestCollections.AddAsync(dalCollection);

            await requestrDbContext.SaveChangesAsync();

            return collection;
        }

        private static Collection MapFromPostman(PostmanImporter.Models.Collection postmanCollection)
        {
            var collection = new Collection()
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

            return collection;
        }
    }
}