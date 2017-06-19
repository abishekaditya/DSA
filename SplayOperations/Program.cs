using System;
using Splay_Tree;
namespace Splay_Operations
{
    internal static class Program
    {
        private static void Main()
        {
            var splay = new SplayTree<int>();
            splay.Insert(3);
            splay.Preorder();
            splay.Insert(5);
            splay.Preorder();
            splay.Insert(7);
            splay.Preorder();
            splay.Insert(6);
            splay.Preorder();
            splay.Find(3);
            splay.Preorder();
            splay.Insert(1);
            splay.Preorder();
            splay.Remove(6);
            splay.Preorder();
            splay.Find(3);
            splay.Preorder();
            splay.Insert(10);
            splay.Insert(2);
            splay.Preorder();
            Console.ReadKey();
        }
    }
}
