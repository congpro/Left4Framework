using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.TreeBuilder
{
    public static class TreeBuilder
    {
        public static BuildRootContext Build(string text)
        {
            var root = new TreeNode(text);
            return new BuildRootContext(root);
        }
        internal static TreeNode<T> BuildNode<T>(T t, Func<T, string> textSelect = null)
        {
            var text = textSelect != null ? textSelect(t) : Convert.ToString(t);
            var node = new TreeNode<T>(text, t);
            return node;
        }
    }

}
