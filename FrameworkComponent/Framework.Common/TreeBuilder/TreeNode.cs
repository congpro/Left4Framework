using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.TreeBuilder
{
    public class TreeNode
    {
        private List<TreeNode> _children;

        public TreeNode(string text, object value = null)
        {
            this.Text = text;
            this.Value = value;
            _children = new List<TreeNode>();
        }

        public string Text { get; private set; }
        public object Value { get; protected set; }
        public TreeNode Parent { get; set; }
        public IEnumerable<TreeNode> Children { get { return _children; } }

        public void Add(TreeNode childNode)
        {
            _children.Add(childNode);
            childNode.Parent = this;
        }
        public void Remove(TreeNode childNode)
        {
            _children.Remove(childNode);
        }
        public override string ToString()
        {
            return Text;
        }
    }

    public class TreeNode<T> : TreeNode
    {
        public TreeNode(string text, T t)
            : base(text, t)
        {
        }
        public new T Value { get { return (T)base.Value; } }

    }
}
