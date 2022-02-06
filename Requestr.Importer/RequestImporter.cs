using Newtonsoft.Json.Linq;
using Requestr.PostmanImporter.Exceptions;
using Requestr.PostmanImporter.Models;

namespace Requestr.PostmanImporter
{
    public class RequestImporter : IRequestImporter
    {
        public Collection Import(string contents)
        {
            var schema = GetSchema(contents);

            if (string.IsNullOrWhiteSpace(schema))
            {
                throw new UnsupportedCollectionFormatVersionException("Unable to determine Postman Collection Format.");
            }

            if (schema != "https://schema.getpostman.com/json/collection/v2.1.0/collection.json")
            {
                const string Error = "Only Postman Collection Format v2.1 is allowed.";

                throw new UnsupportedCollectionFormatVersionException(Error);
            }

            var collection = System.Text.Json.JsonSerializer.Deserialize<Collection>(contents);

            return collection;
        }

        private static string GetSchema(string contents)
        {
            if(string.IsNullOrWhiteSpace(contents))
            {
                return null;
            }

            var jsonContents = JToken.Parse(contents);

            if(jsonContents["info"] == null)
            {
                return null;
            }

            var schema = jsonContents["info"]["schema"];

            return schema?.ToString();
        }
    }
}