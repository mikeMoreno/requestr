using Requestr.Lib.Models;

namespace Requestr.Forms
{
    public class CollectionNode : TreeNode
    {
        public Guid Id { get; set; }

        public Collection Collection { get; set; }
    }
}