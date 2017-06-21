using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Red_Black_Tree
{
    public class RbTree<T> : ITree<T> where T : IComparable
    {

        private INode<T> _rootNode;
        
        public bool IsEmpty => _rootNode == null;

        public RbTree()
        {
            Clear();
        }

        public void Clear()
        {
            _rootNode = null;
        }

        public void Insert(T value)
        {
            INode<T> node = new RbNode<T>(value);
            _rootNode = Insert(_rootNode, node);
            Balance(ref _rootNode,ref node);
        }

        public void Delete(T value)
        {
            throw new NotImplementedException();
        }

        public void Inorder()
        {
            throw new NotImplementedException();
        }

        public void Preorder()
        {
            throw new NotImplementedException();
        }

        public void Postorder()
        {
            throw new NotImplementedException();
        }

        private void Balance(ref INode<T> where,ref INode<T> node)
        {
            if (node == _rootNode)
            {
                node.Colour = Colour.Black;
            }
            while (node != where && node.Colour == Colour.Red && node.Parent.Colour == Colour.Red)
            {
                var parent = node.Parent;
                var grandpa = node.Parent.Parent;
                
                if (parent == grandpa.Left)
                {
                    var uncle = grandpa.Right;
                    if (uncle != null && uncle.Colour == Colour.Red)
                    {
                        grandpa.Colour = Colour.Red;
                        parent.Colour = Colour.Black;
                        uncle.Colour = Colour.Black;
                        node = grandpa;
                    }
                    else
                    {
                        if (node == parent.Right)
                        {
                            RotateLeft(ref where,ref parent);
                            node = parent;
                            parent = node.Parent;
                        }
                        RotateRight(ref where, ref grandpa);
                        var temp = parent.Colour;
                        parent.Colour = grandpa.Colour;
                        grandpa.Colour = temp;
                        node = parent;
                    }
                }
                else
                {
                    var uncle = grandpa.Left;
                    if (uncle != null && uncle.Colour == Colour.Red)
                    {
                        grandpa.Colour = Colour.Red;
                        parent.Colour = Colour.Black;
                        uncle.Colour = Colour.Black;
                        node = grandpa;
                    }
                    else
                    {
                        if (node == parent.Left)
                        {
                            RotateRight(ref where, ref parent);
                            node = parent;
                            parent = node.Parent;
                        }
                        RotateLeft(ref where, ref grandpa);
                        var temp = parent.Colour;
                        parent.Colour = grandpa.Colour;
                        grandpa.Colour = temp;
                        node = parent;
                    }
                }
            }
        }

        private void RotateLeft(ref INode<T> where,ref INode<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;

            if (node.Right != null) node.Right.Parent = node;
            right.Parent = node.Parent;

            if (node.Parent == null) where = right;
            else if (node == node.Parent.Left) node.Parent.Left = right;
            else node.Parent.Right = right;

            right.Left = node;
            node.Parent = right;
        }
        
        private void RotateRight(ref INode<T> where, ref INode<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;

            if (node.Left != null) node.Left.Parent = node;
            left.Parent = node.Parent;

            if (node.Parent == null) where = left;
            else if (node == node.Parent.Left) node.Parent.Left = left;
            else node.Parent.Right = left;

            left.Right = node;
            node.Parent = left;
        }
        
        private static INode<T> Insert(INode<T> where, INode<T> node)
        {
           
            if (where == null)
                return node;
            
            var comp = node.Value.CompareTo(where.Value);
            
            if (comp < 0)
            {
                where.Left = Insert(where.Left, node);
                where.Left.Parent = where;
            }
            else
            {
                where.Right = Insert(where.Right, node);
                where.Right.Parent = where;
            }
            return where;
        }

        
    }
}