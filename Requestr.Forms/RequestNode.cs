using Requestr.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Forms
{
    public class RequestNode : TreeNode
    {
        public Guid Id { get; set; }

        public Request Request { get; init; }
    }
}
