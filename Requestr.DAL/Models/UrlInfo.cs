using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.DAL.Models
{
    public class UrlInfo
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid RequestId { get; set; }

        public string Raw { get; set; }
    }
}
