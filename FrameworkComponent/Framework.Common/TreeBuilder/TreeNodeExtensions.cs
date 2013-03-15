using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.TreeBuilder
{
    public static class TreeNodeExtensions
    {
        public static IEnumerable<TreeNode> GetLeafNodes(this TreeNode treeNode)
        {
            foreach (var child in treeNode.Children)
            {
                if (child.Children.Any())
                {
                    foreach (var descendant in GetLeafNodes(child))
                        yield return descendant;
                }
                else
                    yield return child;
            }
        }
    }

}
