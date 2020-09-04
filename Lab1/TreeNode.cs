using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Lab1
{
    class TreeNode<T> where T:IComparable
    {
        public T[] NodeValues;
        public TreeNode<T>[] SubTrees;

        public bool HasSpace()
        {
            foreach (var value in NodeValues)
            {
                if (value == null)
                {
                    return false;
                }
            }
            return true;
        }

        public TreeNode(T value, int order)
        {
            NodeValues = new T[order - 1];
            SubTrees = new TreeNode<T>[order];
            NodeValues[0] = value;
        }

        public void AddValue(T value)
        {
            for (int i = 0; i < NodeValues.Length; i++)
            {
                if (NodeValues[i] != null)
                {
                    NodeValues[i] = value;
                }
            }
        }
    }
}
