using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Requestr.PostmanImporter
{
    public class CollectionInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("schema")]
        public string Schema { get; set; }
    }
}
