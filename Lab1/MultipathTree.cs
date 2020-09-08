using System;
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
        private List<T> OrderList = new List<T>();

        public MultipathTree(int order)
        {
            TreeOrder = order;
        }

        public void AddValue(T value)
        {
            Insert(value, Root);
        }

        private void Insert(T value, TreeNode<T> node)
        {
            if (node != null)
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
                            if (i - 1 > -1)
                            {
                                if (value.CompareTo(node.NodeValues[i - 1]) > 0)
                                {
                                    if (node.SubTrees[i] == null)
                                    {
                                        node.SubTrees[i] = new TreeNode<T>(value, TreeOrder);
                                    }
                                    else
                                    {
                                        Insert(value, node.SubTrees[i]);
                                    }
                                    i = TreeOrder;
                                }
                            }
                            else
                            {
                                if (node.SubTrees[i] == null)
                                {
                                    node.SubTrees[i] = new TreeNode<T>(value, TreeOrder);
                                }
                                else
                                {
                                    Insert(value, node.SubTrees[i]);
                                }
                                i = TreeOrder;
                            }
                        }
                        else if (value.CompareTo(node.NodeValues[i]) > 0)
                        {
                            if (i + 1 < node.NodeValues.Length)
                            {
                                if (value.CompareTo(node.NodeValues[i + 1]) < 0)
                                {
                                    if (node.SubTrees[i + 1] == null)
                                    {
                                        node.SubTrees[i + 1] = new TreeNode<T>(value, TreeOrder);
                                    }
                                    else
                                    {
                                        Insert(value, node.SubTrees[i + 1]);
                                    }
                                    i = TreeOrder;
                                }
                            }
                            else
                            {
                                if (node.SubTrees[i + 1] == null)
                                {
                                    node.SubTrees[i + 1] = new TreeNode<T>(value, TreeOrder);
                                }
                                else
                                {
                                    Insert(value, node.SubTrees[i + 1]);
                                }
                                i = TreeOrder;
                            }
                            
                        }
                    }
                }
            }
            else if (node == Root)
            {
                Root = new TreeNode<T>(value, TreeOrder);
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

        public List<T> GetPathing(int PathingType)
        {
            OrderList.Clear();
            switch (PathingType)
            {
                case 0:
                    PreOrder(Root);
                    break;
                case 1:
                    InOrder(Root);
                    break;
                case 2:
                    PostOrder(Root);
                    break;
            }
            return OrderList;
        }

        private void PreOrder(TreeNode<T> node)
        {
            for (int i = 0; i < node.NodeValues.Length; i++)
            {
                if (node.NodeValues[i] != null)
                {
                    OrderList.Add(node.NodeValues[i]);
                }
            }
            for (int j = 0; j < node.NodeValues.Length + 1; j++)
            {
                if (node.SubTrees[j] != null)
                {
                    PreOrder(node.SubTrees[j]);
                }
            }
        }

        private void InOrder(TreeNode<T> node)
        {
            for (int i = 0; i < node.NodeValues.Length; i++)
            {
                if (i == 0)
                {
                    if (node.SubTrees[i] != null)
                    {
                        InOrder(node.SubTrees[i]);
                    }
                }
                if (node.NodeValues[i] != null)
                {
                    OrderList.Add(node.NodeValues[i]);
                    if (node.SubTrees[i + 1] != null)
                    {
                        InOrder(node.SubTrees[i + 1]);
                    }
                }
                else
                {
                    i = node.NodeValues.Length;
                }
            }
        }

        private void PostOrder(TreeNode<T> node)
        {
            for (int j = 0; j < node.NodeValues.Length + 1; j++)
            {
                if (node.SubTrees[j] != null)
                {
                    PreOrder(node.SubTrees[j]);
                }
            }
            for (int i = 0; i < node.NodeValues.Length; i++)
            {
                if (node.NodeValues[i] != null)
                {
                    OrderList.Add(node.NodeValues[i]);
                }
            }
        }
    }
}
