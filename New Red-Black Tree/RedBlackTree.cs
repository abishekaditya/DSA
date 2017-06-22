using System;
using System.CodeDom;
using System.Security.Cryptography.X509Certificates;

namespace New_Red_Black_Tree
{
    public class RedBlackTree<T> where T: IComparable
    {
        private Node<T> _root;

        //Helpers
        
        private static bool IsRed(Node<T> x) {
            return x?.Colour == Colour.Red;
        }

        private static int Size(Node<T> x)
        {
            return x?.Size ?? 0;
        }

        public int Size()
        {
            return Size(_root);
        }

        public bool Empty => _root == null;
        
        //Find

        public T Find(T key)
        {
            if (key == null) throw new ArgumentNullException();
            return Find(_root, key);
        }

        private T Find(Node<T> node, T key)
        {
            while (node != null)
            {
                var cmp = key.CompareTo(node.Value);
                if (cmp < 0) node = node.Left;
                else if (cmp > 0) node = node.Right;
                else return node.Value;
            }
            return default(T);
        }

        public bool Contains(T key) => Find(key) != null;

        //Insert

        public void Insert(T key)
        {
            if (key == null) throw new ArgumentNullException();
            _root = Insert(_root, key);
            _root.Colour = Colour.Black;
        }

        private Node<T> Insert(Node<T> node, T key)
        {
            if (node == null) return new Node<T>(key,Colour.Red,1);

            var cmp = key.CompareTo(node.Value);

            if (cmp < 0) node.Left = Insert(node.Left, key);
            else if (cmp > 0) node.Right = Insert(node.Right, key);
            else node.Value = key;

            if (IsRed(node.Right) && !IsRed(node.Left)) node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left)) node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right))  FlipColours(node);
            node.Size = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }



        //Remove

        public void DeleteMin()
        {
            if (Empty) throw new Exception("Underflow");

            if (!IsRed(_root.Left) && !IsRed(_root.Right))
                _root.Colour = Colour.Red;

            _root = DeleteMin(_root);
            if (!Empty) _root.Colour = Colour.Black;
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.Left == null) return null;
            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                node = MoveRedLeft(node);
            node.Left = DeleteMin(node.Left);
            return Balance(node);
        }

        public void DeleteMax()
        {
            if (Empty) throw new Exception("Underflow");

            if (!IsRed(_root.Left) && !IsRed(_root.Right))
                _root.Colour = Colour.Red;

            _root = DeleteMax(_root);
            if (!Empty) _root.Colour = Colour.Black;
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (IsRed(node.Left)) node = RotateRight(node);
            if (node.Right == null) return null;
            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                node = MoveRedRight(node);
            node.Right = DeleteMax(node.Right);
            return Balance(node);
        }

        public void Delete(T key)
        {
            if (key == null) throw new ArgumentNullException();
            if (!Contains(key)) return;
            if (!IsRed(_root.Left) && !IsRed(_root.Right))
                _root.Colour = Colour.Red;
            _root = Delete(_root, key);
            if (!Empty) _root.Colour = Colour.Black;
        }

        private Node<T> Delete(Node<T> node, T key)
        {
            if (key.CompareTo(node.Value) < 0)
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                    node = MoveRedLeft(node);
                node.Left = Delete(node.Left, key);
            }
            else
            {
                if (IsRed(node.Left)) node = RotateRight(node);
                var cmp = key.CompareTo(node.Value);
                if (cmp == 0 && node.Right == null) return null;
                if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                    node = MoveRedRight(node);
                if (cmp == 0)
                {
                    var x = Min(node.Right);
                    node.Value = x.Value;
                    node.Right = DeleteMin(node.Right);
                }
                else node.Right = Delete(node.Right, key);
            }
            return Balance(node);
        }
        //Printing

        public void Inorder()
        {
            Inorder(_root);
            Console.WriteLine();
        }

        private static void Inorder(Node<T> node)
        {
            if (node == null) return;
            Inorder(node.Left);
            Console.Write($"( {node.Value} : {node.Colour} ) ");
            Inorder(node.Right);
        }

        public void Preorder()
        {
            Preorder(_root);
            Console.WriteLine();
        }

        private static void Preorder(Node<T> node)
        {
            if (node == null) return;
            Console.Write($"( {node.Value} : {node.Colour} ) ");
            Preorder(node.Left);
            Preorder(node.Right);
        }

        public void Postorder()
        {
            Postorder(_root);
            Console.WriteLine();
        }

        private static void Postorder(Node<T> node)
        {
            if (node == null) return;
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write($"( {node.Value} : {node.Colour} ) ");
        }

        //Helpers

        private static Node<T> Min(Node<T> node)
        {
            while (true)
            {
                if (node.Left == null) return node;
                node = node.Left;
            }
        }

        private Node<T> Balance(Node<T> node)
        {
            if (IsRed(node.Right)) node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left.Left)) node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right)) FlipColours(node);
            node.Size = Size(node.Left) + Size(node.Right) + 1;
            return node;
        }


        private Node<T> MoveRedLeft(Node<T> node)
        {
            FlipColours(node);
            if (!IsRed(node.Right.Left)) return node;
            node.Right = RotateRight(node.Right);
            node = RotateLeft(node);
            FlipColours(node);
            return node;
        }

        private Node<T> MoveRedRight(Node<T> node)
        {
            FlipColours(node);
            if (!IsRed(node.Left.Left)) return node;
            node = RotateRight(node);
            FlipColours(node);
            return node;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var x = node.Left;
            if (x == null) return node;
            node.Left = x.Right;
            x.Right = node;
            x.Colour = x.Right.Colour;
            x.Right.Colour = Colour.Red;
            x.Size = node.Size;
            node.Size = Size(node.Left) + Size(node.Right) + 1;
            return x;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var x = node.Right;
            if (x == null) return node;
            node.Right = x.Left;
            x.Left = node;
            x.Colour = x.Left.Colour;
            x.Left.Colour = Colour.Red;
            x.Size = node.Size;
            node.Size = Size(node.Left) + Size(node.Right) + 1;
            return x;
        }

        private void FlipColours(Node<T> node)
        {
            if (node == _root)
            {
                node.Colour = 1 - node.Colour;
                return;
            }
            node.Colour = 1 - node.Colour;
            node.Left.Colour = 1 - node.Left.Colour;
            node.Right.Colour = 1 - node.Right.Colour;
        }

    }
}