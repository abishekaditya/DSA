using System;
using Heap;
namespace Huffman
{
    public class HuffmanTree<T> : IComparable<HuffmanTree<T>>
    {
        public IHuffNode RootNode { get; }

        public HuffmanTree(T element, int weight)
        {
            RootNode = new HuffLNode<T>(element,weight);
        }

        public HuffmanTree(IHuffNode lNode, IHuffNode rNode, int weight)
        {
            RootNode = new HuffINode(lNode,rNode,weight);
        }

        public int Weight => RootNode.Weight;
        
        public int CompareTo(HuffmanTree<T> other)
        {
            return RootNode.Weight < other.Weight ? -1 : (RootNode.Weight == other.Weight ? 0 : 1);
        }

        public void Print()
        {
            PrintHelp(RootNode);
        }

        private static void PrintHelp(IHuffNode node)
        {
            if (node is HuffINode x)
            {
                Console.WriteLine("\nNode : " + node.Weight);
                PrintHelp(x.LeftNode);
                PrintHelp(x.RightNode);
            }
            if (node.Leaf)
            {
                Console.WriteLine($" Leaf : {node.Weight}");
            }
        }

    }
}