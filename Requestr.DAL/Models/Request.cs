using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.DAL.Models
{
    public class Request
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public Guid RequestCollectionId { get; set; }

        public virtual RequestCollection RequestCollection { get; set; }

        public virtual List<RequestHeader> RequestHeaders { get; set; }
    }
}
