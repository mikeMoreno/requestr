using Requestr.PostmanImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Forms
{
    public class RequestNode : TreeNode
    {
        public RequestItem? RequestItem { get; init; }
    }
}
