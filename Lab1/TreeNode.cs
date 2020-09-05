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
                if (NodeValues[i] != null) //Revisar lógica (NodeValues[i] == null)? 
                {
                    NodeValues[i] = value;
                    //i = NodeValues.Length;
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
                    if(this[j] == null)
                    {
                        i = NodeValues.Length -1;
                        j = NodeValues.Length;
                    }
                    else
                    {
                        if(this[i].CompareTo(this[j]) == 1)
                        {
                        aux = this[i];
                        this[i] = this[j];
                        this[j] = aux;
                        }
                    } 
			   }
            }
        }
      
    }
}
