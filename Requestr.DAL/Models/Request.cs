using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.DAL.Models
{
    public class Request
    {
        public Guid Id { get; set; }

        public string Method { get; set; }

        public string Name { get; set; }

    }
}
