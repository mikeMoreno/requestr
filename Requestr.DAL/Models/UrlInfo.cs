using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.DAL.Models
{
    public class UrlInfo
    {
        public Guid Id { get; set; }

        public Guid RequestId { get; set; }

        public string Raw { get; set; }


        public string Protocol { get; set; }


        public string[] Host { get; set; }


        public string Port { get; set; }
    }
}
