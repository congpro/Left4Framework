using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Common.TreeBuilder
{
    public class BuildChildrenContext<T> 
    {
        private TreeNode _tree;

        public BuildChildrenContext(TreeNode tree) {
            this._tree = tree;
        }

        public TreeNode Tree { get { return _tree; } }

        public BuildChildrenContext<V> SetItems<V>(Func<T, IEnumerable<V>> itemSelector, Func<V, string> textSelect = null) 
        {
            var leafNodes = _tree.GetLeafNodes().OfType<TreeNode<T>>();
            foreach (var leafNode in leafNodes) 
            {
                foreach (var child in itemSelector(leafNode.Value)) 
                {
                    var node = TreeBuilder.BuildNode(child, textSelect);
                    leafNode.Add(node);
                }
            }
            return new BuildChildrenContext<V>(_tree);
        }
        public BuildChildrenContext<T> SetRecursiveItems(Func<T, IEnumerable<T>> itemSelector,
            Func<T, string> textSelect = null) 
        {
            var context = this;
            while (_tree.GetLeafNodes().OfType<TreeNode<T>>().Any(n => itemSelector(n.Value).Any()))
                context = context.SetItems<T>(itemSelector, textSelect);
            return context;
        }
    }
}
