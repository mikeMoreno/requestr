using Requestr.Lib.Exceptions;
using Requestr.PostmanImporter;
using Requestr.PostmanImporter.Exceptions;
using Requestr.PostmanImporter.Models;

namespace Requestr.Lib
{
    public class ImportService
    {
        private readonly RequestImporter postmanImporter;

        public ImportService(RequestImporter postmanImporter)
        {
            this.postmanImporter = postmanImporter;
        }

        public Models.Collection Import(string fileContents)
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

            return collection;
        }
    }
}