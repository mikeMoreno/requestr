﻿using Requestr.PostmanImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Forms
{
    public class RequestNode : TreeNode
    {
        public Guid Key { get; set; }

        public RequestItem? RequestItem { get; init; }
    }
}
