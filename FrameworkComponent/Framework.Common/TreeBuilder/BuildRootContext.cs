using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.TreeBuilder
{
    public class BuildRootContext
    {
        private TreeNode _tree;

        public BuildRootContext(TreeNode tree)
        {
            this._tree = tree;
        }

        public BuildChildrenContext<T> SetItems<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var node = TreeBuilder.BuildNode(item);
                _tree.Add(node);
            }
            return new BuildChildrenContext<T>(_tree);
        }
        public TreeNode Tree { get { return _tree; } }
    }

}
