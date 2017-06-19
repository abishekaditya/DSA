using System;
using Heap;
using Huffman;

namespace Huffman_Tree_Construction
{
    internal static class Program
    {
        private static void Main()
        {
            var a = new HuffLNode<char>('D', 32);
            var b = new HuffLNode<char>('C', 42);
            var c = new HuffLNode<char>('E', 120);
            var d = new HuffLNode<char>('K', 7);
            var e = new HuffLNode<char>('L', 42);
            var f = new HuffLNode<char>('M', 24);
            var g = new HuffLNode<char>('U', 37);
            var h = new HuffLNode<char>('Z', 2);
            var heap = new MinHeap<IHuffNode>(new IHuffNode[] {a, b, c, d, e, f, g, h}, 15);
            var huffmanTree = HuffmanTree<IHuffNode>.HuffmanBuilder(heap);
            huffmanTree.Print();
            Console.ReadLine();
        }
    }
}