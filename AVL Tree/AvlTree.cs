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

        private INode<T> Insert(INode<T> where, INode<T> node)
        {
            if (where == null)
            {
                return node;
            }

            var comp = where.Value.CompareTo(node.Value);
            if (comp == 0)
            {
                where.Value = node.Value;
            }
            else if (comp < 0)
            {
                where.Right = Insert(where.Right, node);
            }
            else
            {
                where.Left = Insert(where.Left, node);
            }

            return where.Balance();
        }

        private INode<T> Delete(INode<T> node, T value)
        {
            if (node == null) throw new ArgumentOutOfRangeException();
            var comp = node.Value.CompareTo(value);

            if (comp == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                if (node.Left == null)
                {
                    return node.Right;
                }
                if (node.Right == null)
                {
                    return node.Left;
                }
                var left = node.Right;
                while (left.Left != null)
                {
                    left = left.Left;
                }

                left.Right = DeleteLeft(node.Right);
                left.Left = node.Left;
                return left.Balance();
            }
            if (comp >= 0)
                node.Right = Delete(node.Right, value);
            else
                node.Left = Delete(node.Left, value);

            return node.Balance();
        }

        private static INode<T> DeleteLeft(INode<T> node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            node.Left = DeleteLeft(node.Left);
            return node.Balance();
        }


        public void Insert(T value)
        {
            _rootNode = Insert(_rootNode, new AvlNode<T>(value));
        }
        
        public void Delete(T value)
        {
            _rootNode = Delete(_rootNode, value);
        }

        public void Inorder()
        {
            Inorder(_rootNode);
            Console.WriteLine();
        }

        private static void Inorder(INode<T> node)
        {
            if (node == null) return;
            Inorder(node.Left);
            Console.Write(node.Value + " ");
            Inorder(node.Right);
        }

        public void Preorder()
        {
            Preorder(_rootNode);
            Console.WriteLine();
        }

        private static void Preorder(INode<T> node)
        {
            if (node == null) return;
            Console.Write(node.Value + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }

        public void Postorder()
        {
            Postorder(_rootNode);
            Console.WriteLine();
        }

        private static void Postorder(INode<T> node)
        {
            if (node == null) return;
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Value + " ");
        }
    }
}