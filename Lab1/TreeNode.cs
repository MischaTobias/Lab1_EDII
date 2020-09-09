using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab1
{
    class TreeNode<T> where T:IComparable
    {
        public T[] NodeValues;
        public TreeNode<T>[] SubTrees;
        private List<T> ListaOrder = new List<T>();

        //https://stackoverflow.com/questions/65351/null-or-default-comparison-of-generic-argument-in-c-sharp
        public bool HasSpace()
        {
            foreach (var value in NodeValues)
            {
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return true;
                }
            }
            return false;
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
                if (EqualityComparer<T>.Default.Equals(NodeValues[i], default(T))) 
                {
                    NodeValues[i] = value;
                    i = NodeValues.Length;
                }
            }
            NodeOrder();
        }

        public void NodeOrder()
        {
            T aux;
            for (int i = 0; i < NodeValues.Length - 1; i++)
            {
               for (int j = i+1 ; j < NodeValues.Length; j++)
			   {
                    if(NodeValues[j] == null)
                    {
                        i = NodeValues.Length -1;
                        j = NodeValues.Length;
                    }
                    else
                    {
                        if(NodeValues[i].CompareTo(NodeValues[j]) > 0)
                        {
                            aux = NodeValues[i];
                            NodeValues[i] = NodeValues[j];
                            NodeValues[j] = aux;
                        }
                    } 
			   }
            }
        }
    }
}
