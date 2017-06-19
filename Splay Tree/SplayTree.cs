using System;
using System.Collections.Generic;

namespace Splay_Tree
{
    public class SplayTree<T> where T : IComparable<T>
    {
        private ISplayNode<T> _rootNode;
        private readonly HashSet<ISplayNode<T>> _wasRead = new HashSet<ISplayNode<T>>();

        public void Clear()
        {
            _rootNode = null;
            _wasRead.Clear();
        }

        private void Splay(ISplayNode<T> node)
        {
            while (node.Parent != null)
            {
                if (node.Parent.Parent == null)
                {
                    if (node.Parent.Left == node)
                        RotateR(node.Parent);
                    else
                        RotateL(node.Parent);
                }
                else if (node.Parent.Left == node && node.Parent.Parent.Left == node.Parent)
                {
                    RotateR(node.Parent.Parent);
                    RotateR(node.Parent);
                }
                else if (node.Parent.Right == node && node.Parent.Parent.Right == node.Parent )
                {
                    RotateL(node.Parent.Parent);
                    RotateL(node.Parent);
                }
                else if (node.Parent.Left == node && node.Parent.Parent.Right == node.Parent)
                {
                    RotateR(node.Parent.Parent);
                    RotateL(node.Parent);
                }
                else
                {
                    RotateL(node.Parent.Parent);
                    RotateR(node.Parent);
                }

            }
        }

        public T Find(T key)
        {
            var node = FindHelper(key);
            Splay(node);

            return key.CompareTo(_rootNode.Value) == 0 ? _rootNode.Value : default(T);
        }

        private ISplayNode<T> FindHelper(T key)
        {
            var current = _rootNode;
            var prev = current;
            while (current != null)
            {
                prev = current;
                if (!_wasRead.Contains(current))
                {
                    _wasRead.Add(current);
                }
                var cmp = key.CompareTo(current.Value);

                if (cmp < 0) current = current.Left;
                else if (cmp > 0) current = current.Right;
                else return current;
            }
            return prev;
        }

        public void Insert(T key)
        {
            if (_rootNode == null)
            {
                _rootNode = new SplayNode<T>(key);
                return;
            }
            var node = FindHelper(key);
            Splay(node);
            var cmp = key.CompareTo(_rootNode.Value);
            if (cmp < 0)
            {
                var newNode = new SplayNode<T>(key)
                {
                    Left = _rootNode.Left,
                    Parent = _rootNode
                };
                if (newNode.Left != null) newNode.Left.Parent = newNode;
                _rootNode.Left = newNode;
                Splay(newNode);
            }
            else if (cmp > 0)
            {
                var newNode = new SplayNode<T>(key)
                {
                    Right = _rootNode.Right,
                    Parent = _rootNode
                };
                if (newNode.Right != null) newNode.Right.Parent = newNode;
                _rootNode.Right = newNode;
                Splay(newNode);
            }
        }

        private void RotateR(ISplayNode<T> father)
        {
            var son = father.Left;
            if (son != null)
            {
                if (son.Right != null) son.Right.Parent = father;
                father.Left = son.Right;
                son.Parent = father.Parent;
                son.Right = father;
            }

            if (father.Parent == null) _rootNode = son;
            else if (father == father.Parent.Left) father.Parent.Left = son;
            else father.Parent.Right = son;

            father.Parent = son;
        }

        private void RotateL(ISplayNode<T> parent)
        {
            var son = parent.Right;
            if (son != null)
            {
                if (son.Left != null) son.Left.Parent = parent;
                parent.Right = son.Left;
                son.Parent = parent.Parent;
                son.Left = parent;
            }

            if (parent.Parent == null) _rootNode = son;
            else if (parent == parent.Parent.Left) parent.Parent.Left = son;
            else parent.Parent.Right = son;

            parent.Parent = son;
        }

        public void Inorder()
        {
            Inorder(_rootNode);
            Console.WriteLine();
        }

        private static void Inorder(ISplayNode<T> node)
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

        private static void Preorder(ISplayNode<T> node)
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

        private static void Postorder(ISplayNode<T> node)
        {
            if (node == null) return;
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Value + " ");
        }

        public T Remove(T key)
        {
            var temp = FindHelper(key);
            if (temp == null) return default(T);
            Splay(temp);
            _wasRead.Remove(temp);
            _rootNode = RemoveRoot(_rootNode);

            return temp.Value;
        }

        private static ISplayNode<T> RemoveRoot(ISplayNode<T> rootNode)
        {
            if (rootNode == null)
                return null;
            if (rootNode.Left == null)
                    return rootNode.Left;
            if (rootNode.Right == null)
                    return rootNode.Right;
            
            var temp = GetMax(rootNode.Left);
            rootNode.Value = temp.Value;
            rootNode.Left = DeleteMax(rootNode.Left);
            return rootNode;
        }

        private static ISplayNode<T> DeleteMax(ISplayNode<T> node)
        {
            if (node.Right == null)
                return node.Left;
            node.Right = DeleteMax(node.Right);
            return node;
        }

        private static ISplayNode<T> GetMax(ISplayNode<T> node)
        {
            while (true)
            {
                if (node.Right == null) return node;
                node = node.Right;
            }
        }
    }
}