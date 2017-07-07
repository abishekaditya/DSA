using BTree;

namespace BTree_Operations
{
    internal static class Program
    {
        private static void Main()
        {
            var tree = new BTree<int>(2);
            tree.Insert(12);
            tree.Insert(5);
            tree.Insert(11);
            tree.Insert(3);
            tree.Insert(1);
            tree.Insert(7);
            tree.Print();
            tree.Remove(5);
            tree.Print();
        }
    }
}