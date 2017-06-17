using System;

namespace Huffman
{
    public interface IHuffNode : IComparable
    {
        bool Leaf { get; }
        int Weight { get; }
    }
}