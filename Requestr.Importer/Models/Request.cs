using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Requestr.PostmanImporter.Models
{
    public class Request
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }


        [JsonPropertyName("header")]
        public RequestHeader[] RequestHeaders { get; set; }


        [JsonPropertyName("url")]
        public UrlInfo Url { get; set; }
    }
}
