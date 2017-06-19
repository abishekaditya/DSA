using System;

namespace Splay_Tree
{
    public class SplayNode<T> : ISplayNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public ISplayNode<T> Parent { get; set; }
        public ISplayNode<T> Left { get; set; }
        public ISplayNode<T> Right { get; set; }

        public SplayNode(T value)
        {
            Value = value;
        }
       
    }
}