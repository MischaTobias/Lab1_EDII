﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        public T Search(T value)
        {
            return Get(value, Root);
        }

        private T Get(T value, TreeNode<T> node)
        {
            for (int i = 0; i < node.NodeValues.Length; i++)
            {
                if (value.CompareTo(node.NodeValues[i]) < 0)
                {
                    return Get(value, node.SubTrees[i]);
                }
                else if (value.CompareTo(node.NodeValues[i]) > 0)
                {
                    return Get(value, node.SubTrees[i + 1]);
                }
                else if (value.CompareTo(node.NodeValues[i]) == 0)
                {
                    return node.NodeValues[i];
                }
            }
            return default;
        }

        //public List<T> GetPathing(int pathingType)
        //{
        //    switch (pathingType)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            break;
        //        case 2:
        //            break;
        //    }
        //    return new List<T>();
        //}

        //private List<T> PreOrder(TreeNode<T> node)
        //{
        //    List<T> Values = new List<T>();
        //    for (int i = 0; i < node.NodeValues.Length; i++)
        //    {
        //        if (node.NodeValues[i] != null)
        //        {
        //            Values.Add(node.NodeValues[i]);
        //        }
        //    }
        //    return new List<T>();
        //}

        //private List<T> InOrder(TreeNode<T> node)
        //{
        //    return new List<T>();
        //}

        //private List<T> PostOrder(TreeNode<T> node)
        //{
        //    return new List<T>();
        //}
    }
}
