using System;
using static Utilities.Utilities;

namespace AVL_Tree
{
    public class AvlTree<T> where T : IComparable
    {
        private INode<T> _rootNode;

        public AvlTree()
        {
            _rootNode = null;
        }

        public bool IsEmpty => _rootNode == null;

        public void Clear()
        {
            _rootNode = null;
        }

        public void Insert(T data)
        {
            _rootNode = InsertHelper(_rootNode, data);
        }

        private static int Height(INode<T> t)
        {
            return t?.Height ?? -1;
        }

        private static INode<T> InsertHelper(INode<T> node, T data)
        {
            if (node == null)
                node = new AvlNode<T>(data);
            else if (data.CompareTo(node.Value) < 0)
            {
                node.LNode = InsertHelper(node.LNode, data);
                if (Height(node.LNode) - Height(node.RNode) == 2)
                {

                    node = data.CompareTo(node.LNode.Value) < 0 ? RotateLeft(node) : DoubleLeft(node);
                }
            }
            else if (data.CompareTo(node.Value) > 0)
            {
                node.RNode = InsertHelper(node.RNode, data);
                if (Height(node.RNode) - Height(node.LNode) == 2)
                {
                    node = data.CompareTo(node.RNode.Value) < 0 ? RotateRight(node) : DoubleRight(node);
                }
            }
            node.Height = Max(Height(node.LNode), Height(node.RNode)) + 1;
            return node;
        }

        private static INode<T> DoubleRight(INode<T> parentNode)
        {
            parentNode.RNode = RotateLeft(parentNode.RNode);
            return RotateRight(parentNode);
        }

        private static INode<T> RotateRight(INode<T> parentNode)
        {
            var pivot = parentNode.RNode;
            parentNode.RNode = pivot.LNode;
            pivot.LNode = parentNode;
            parentNode.Height = Max(Height(parentNode.LNode), Height(parentNode.RNode)) + 1;
            pivot.Height = Max(Height(pivot.LNode), parentNode.Height) + 1;
            return pivot;
        }

        private static INode<T> DoubleLeft(INode<T> parentNode)
        {
            parentNode.LNode = RotateRight(parentNode.LNode);
            return RotateLeft(parentNode);
        }

        private static INode<T> RotateLeft(INode<T> parentNode)
        {
            var pivot = parentNode.LNode;
            parentNode.LNode = pivot.RNode;
            pivot.RNode = parentNode;
            parentNode.Height = Max(Height(parentNode.LNode), Height(parentNode.RNode)) + 1;
            pivot.Height = Max(Height(pivot.LNode), parentNode.Height) + 1;
            return pivot;
        }


        public bool Search(T val)
        {
            return Search(_rootNode, val);
        }

        private static bool Search(INode<T> node, T val)
        {
            var found = false;
            while ((node != null) && !found)
            {

                var rval = node.Value;
                if (val.CompareTo(rval) < 0)
                    node = node.LNode;
                else if (val.CompareTo(rval) > 0)
                    node = node.RNode;
                else
                {
                    found = true;
                    break;
                }
                found = Search(node, val);
            }
            return found;
        }

        public void Inorder()
        {
            Inorder(_rootNode);
        }

        private static void Inorder(INode<T> node)
        {
            if (node == null) return;
            Inorder(node.LNode);
            Console.WriteLine(node.Value + " ");
            Inorder(node.RNode);
        }

        public void Preorder()
        {
            Preorder(_rootNode);
        }

        private static void Preorder(INode<T> node)
        {
            if (node == null) return;
            Console.WriteLine(node.Value + " ");
            Preorder(node.LNode);
            Preorder(node.RNode);
        }

        public void Postorder()
        {
            Postorder(_rootNode);
        }

        private static void Postorder(INode<T> node)
        {
            if (node == null) return;
            Postorder(node.LNode);
            Postorder(node.RNode);
            Console.WriteLine(node.Value + " ");
        }
    }
}