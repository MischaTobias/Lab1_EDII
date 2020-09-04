using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab1
{
    public class MultipathTree<T> where T : IComparable
    {
        private int TreeOrder;
        private TreeNode<T> Root;

        public MultipathTree(int order, T value)
        {
            TreeOrder = order;
            TreeNode<T> newNode = new TreeNode<T>(value, order);
        }

        public void AddValue(T value)
        {
            Insert(value, Root);
        }

        private void Insert(T value, TreeNode<T> node)
        {
            if (node.HasSpace())
            {
                node.AddValue(value);
            }
            else
            {
                for (int i = 0; i < TreeOrder - 1; i++)
                {
                    if (value.CompareTo(node.NodeValues[i]) < 0)
                    {
                        Insert(value, node.SubTrees[i]);
                    }
                    else if (value.CompareTo(node.NodeValues[i]) > 0)
                    {
                        Insert(value, node.SubTrees[i + 1]);
                    }
                }
            }
        }
        public void Search(T value) { }
        public void Pathing(int pathingType) { }
    }
}
    