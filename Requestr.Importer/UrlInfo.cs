using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Requestr.PostmanImporter
{
    public class UrlInfo
    {
        [JsonPropertyName("raw")]
        public string Raw { get; set; }


        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }


        [JsonPropertyName("host")]
        public string[] Host { get; set; }


        [JsonPropertyName("port")]
        public string Port { get; set; }


        [JsonPropertyName("path")]
        public string[] Path { get; set; }


        [JsonPropertyName("query")]
        public QueryKeyValue[] Query { get; set; }
    }
}
