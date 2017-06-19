using System;

namespace Splay_Tree
{
    public interface ISplayNode<T> where T : IComparable<T>
    {
        T Value { get; set; }
        ISplayNode<T> Parent { get; set; }
        ISplayNode<T> Left { get; set; }
        ISplayNode<T> Right { get; set; }
    }
}