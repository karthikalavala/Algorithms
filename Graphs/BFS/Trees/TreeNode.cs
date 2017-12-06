using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class TreeNode<T>
    {
        private T value;

        private bool hasParent;

        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
                throw new ArgumentNullException("Cannot insert null value");

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
			if(child ==null)
                throw new ArgumentNullException("Cannot insert null value");
            if (child.hasParent == true)
                throw new ArgumentNullException("Node already has a parent");

            child.hasParent = true;
            this.children.Add(child);
        }
        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
}
