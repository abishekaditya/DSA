using System;

namespace Red_Black_Tree
{
    public interface INode<T>
    {
        T Value { get; set; }
        Colour Colour { get; set; }
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        INode<T> Parent { get; set; }
    }
}