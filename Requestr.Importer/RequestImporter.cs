using Requestr.PostmanImporter.Exceptions;
using Requestr.PostmanImporter.Models;

namespace Requestr.PostmanImporter
{
    public class RequestImporter : IRequestImporter
    {
        public Collection Import(string contents)
        {
            var collection = System.Text.Json.JsonSerializer.Deserialize<Collection>(contents);

            if (collection.Info.Schema != "https://schema.getpostman.com/json/collection/v2.1.0/collection.json")
            {
                const string Error = "Only Postman Collection Format v2.1 is allowed.";

                throw new UnsupportedCollectionFormatVersionException(Error);
            }

            return collection;
        }
    }
}