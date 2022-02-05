using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Lib.Models
{
    public class Collection
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Request> Requests { get; set; } = new List<Request>();
    }
}
