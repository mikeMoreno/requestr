using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Requestr.PostmanImporter.Models
{
    public class RequestItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("request")]
        public Request Request { get; set; }
    }
}
