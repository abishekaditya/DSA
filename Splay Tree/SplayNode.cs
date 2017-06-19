using System;

namespace Splay_Tree
{
    public class SplayNode<T> : ISplayNode<T> where T : IComparable<T>
    {
        public SplayNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public ISplayNode<T> Parent { get; set; }
        public ISplayNode<T> Left { get; set; }
        public ISplayNode<T> Right { get; set; }
    }
}