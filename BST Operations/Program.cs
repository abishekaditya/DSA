using System;
using BinarySearchTree;

namespace BST_Operations
{
    internal static class Program
    {
        private static void Main()
        {
            var tree = new BsTree<int,char>();
            tree.Insert(22, 'G');
            tree.Insert(511, 'E');
            tree.Insert(45,'X');
            tree.Clear();
            tree.Insert(43, 'H');
            tree.Insert(25, 'G');
            tree.Insert(55, 'E');
            tree.Insert(62, 'F');
            tree.Remove(62);
            tree.Insert(21, 'D');
            tree.Print();
            Console.WriteLine(tree.Length);
            Console.WriteLine(tree.Find(25));
            Console.ReadLine();
        }
    }
}
