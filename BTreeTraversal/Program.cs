using Link;
using System;
using System.Xml;

namespace BTreeTraversal
{
    internal static class Program
    {
        private static void Main()
        {
            var dNode = new BinNode<char, int>('D',14);
            var bNode = new BinNode<char, int>('B', 13, null, dNode);
            var hNode = new BinNode<char, int>('H', 22);
            var iNode = new BinNode<char, int>('I', 41);
            var fNode = new BinNode<char, int>('F', 44, hNode, iNode) ;
            var gNode = new BinNode<char, int>('G', 22);
            var eNode = new BinNode<char, int>('E', 54, gNode, null);
            var cNode = new BinNode<char, int>('C', 12, eNode, fNode);
            var aNode = new BinNode<char,int>('A', 23, bNode, cNode);
            

            BinNode<char,int>.Preorder(aNode);
            Console.ReadLine(); Console.Clear();
            BinNode<char,int>.Inorder(aNode);
            Console.ReadLine(); Console.Clear();
            BinNode<char,int>.Postorder(aNode);
            Console.ReadLine(); Console.Clear();
            Console.WriteLine(BinNode<char,int>.Search(aNode, 'F'));
            Console.ReadLine(); Console.Clear();

        }
    }
}
