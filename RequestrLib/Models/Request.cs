using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Lib.Models
{
    public class Request
    {
        public Guid Id { get; set; }

        public Guid RequestCollectionId { get; set; }

        public string Name { get; set; }

        public string Method { get; set; }

        public string Url { get; set; }

        public List<RequestHeader> RequestHeaders { get; set; } = new List<RequestHeader>();
    }
}
