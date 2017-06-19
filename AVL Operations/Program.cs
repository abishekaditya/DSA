using System;
using AVL_Tree;
namespace AVL_Operations
{
    internal static class Program
    {
        private static void Main()
        {
            var tree = new AvlTree<int>();
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(9);
            Console.ReadKey();
            tree.Preorder();
            Console.ReadKey();
        }
    }
}
