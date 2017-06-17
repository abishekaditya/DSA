using System;
using System.Net.Http.Headers;

namespace Huffman
{
    public class HuffINode : IHuffNode
    {

        public IHuffNode LeftNode { get; private set; }
        public IHuffNode RightNode { get; private set; }

        public bool Leaf => false;

        public int Weight { get; }

        public HuffINode(IHuffNode leftNode, IHuffNode rightNode, int weight)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
            Weight = weight;
        }


        public int CompareTo(object obj)
        {
            var item = (IHuffNode)obj;
            return (item.Weight > Weight) ? -1 : (item.Weight == Weight) ? 0 : 1;
        }
    }
}