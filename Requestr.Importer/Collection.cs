//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Requestr.PostmanImporter
{
    public class Collection
    {
        [JsonPropertyName("info")]
        public CollectionInfo Info { get; set; }


        [JsonPropertyName("item")]
        public RequestItem[] Item { get; set; }
    }
}
