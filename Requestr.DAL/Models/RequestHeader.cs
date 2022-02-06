using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.DAL.Models
{
    public class RequestHeader
    {
        [Required]
        public Guid Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }

        [Required]
        public Guid RequestId { get; set; }

        public virtual Request Request { get; set; }
    }
}
