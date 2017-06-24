using System;
using System.Collections.Generic;

namespace BTree
{
    public class BNode<T> where T : IComparable
    {
        public readonly T[] Keys;
        private int Size { get; }
        public readonly BNode<T>[] Children;
        public int NumKeys;
        private bool Leaf { get; }

        public BNode(int size, bool leaf)
        {
            Keys = new T[2*size-1];
            Size = size;
            Children = new BNode<T>[2*size];
            NumKeys = 0;
            Leaf = leaf;
        }

        public void Traverse()
        {
            int i;
            for (i = 0; i < NumKeys; i++)
            {
                if(!Leaf) Children[i].Traverse();
                Console.Write(Keys[i] + " ");
            }
            
            if(!Leaf) Children[i].Traverse();
        }

        public BNode<T> Search(T key)
        {
            var i = 0;
            while (i < NumKeys && key.CompareTo(Keys[i]) > 0)
                i++;

            return Keys[i].Equals(key) ? null : Children[i].Search(key);
        }

        public void InsertNonFull(T key)
        {
            var i = NumKeys - 1;

            if (Leaf)
            {
                while (i >= 0 && Keys[i].CompareTo(key) > 0)
                {
                    Keys[i + 1] = Keys[i];
                    i--;
                }

                Keys[i + 1] = key;
                NumKeys += 1;
            }
            else
            {
                while (i >= 0 && Keys[i].CompareTo(key) > 0)
                    i--;

                if (Children[i + 1].NumKeys == 2 * Size - 1)
                {
                    SpiltChild(i + 1, Children[i + 1]);
                    if (Keys[i + 1].CompareTo(key) < 0)
                        i++;
                }
                Children[i+1].InsertNonFull(key);
            }
        }

        public void SpiltChild(int i, BNode<T> node)
        {
            var newNode = new BNode<T>(node.Size, node.Leaf) {NumKeys = Size - 1};

            for (var j = 0; j < Size-1; j++)
                newNode.Keys[j] = node.Keys[j + Size];
            

            if (!node.Leaf)
            {
                for (var j = 0; j < Size; j++)
                    newNode.Children[j] = node.Children[j + Size];
                
            }
            node.NumKeys = Size - 1;

            for (var j = NumKeys; j >= i+1; j--)
                Children[j + 1] = Children[j];
            
            Children[i + 1] = newNode;

            for (var j = NumKeys-1; j >= i; j--)
                Keys[j + 1] = Keys[j];

            Keys[i] = node.Keys[Size - 1];
            NumKeys += 1;
        }
    }
}