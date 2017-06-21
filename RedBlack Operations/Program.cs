﻿using System;
using Red_Black_Tree;
namespace RedBlack_Operations
{
    internal static class Program
    {
        private static void Main()
        {
            var rbtree = new RbTree<int>();
            rbtree.Insert(3);
            rbtree.Insert(2);
            rbtree.Insert(5);
            rbtree.Insert(7);
            rbtree.Insert(6);
            Console.ReadLine();
        }
    }
}