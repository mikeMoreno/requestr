using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Requestr.PostmanImporter
{
    public class RequestItem
    {
        public Guid Key { get; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("request")]
        public Request Request { get; set; }

        public RequestItem()
        {
            Key = Guid.NewGuid();
        }
    }
}
