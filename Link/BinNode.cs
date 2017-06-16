using System;

namespace Link
{
    public class BinNode<TKey, TValue> : IBNode<TValue> where TKey : IComparable
    {
        private BinNode<TKey,TValue> _right;
        private BinNode<TKey, TValue> _left;
        public TValue Element { get; set; }

        public IBNode<TValue> LeftNode
        {
            get => _left;
            set => _left = (BinNode<TKey, TValue>) value;
        }

        public IBNode<TValue> RightNode
        {
            get => _right;
            set => _right = (BinNode<TKey, TValue>) value;
        }


        public bool IsLeaf => (_left == null && _right == null);

        public TKey Key { get; set; }

        public BinNode()
        {
            _right = _left = null;
        }

        public BinNode(TKey key, TValue value)
        {
            _right = _left = null;
            Key = key;
            Element = value;
        }

        public BinNode(TKey key, TValue value, BinNode<TKey,TValue> leftNode, BinNode<TKey,TValue> rightNode)
        {
            _right = rightNode;
            _left = leftNode;
            Key = key;
            Element = value;
        }

        public static void Preorder(BinNode<TKey, TValue> rt)
        {
            while (true)
            {
                if (rt == null) return;
                Console.WriteLine(rt.Key + " " + rt.Element);
                Preorder((BinNode<TKey, TValue>) rt.LeftNode);
                rt = (BinNode<TKey, TValue>) rt.RightNode;
            }
        }

        public static void Postorder(BinNode<TKey, TValue> rt)
        {
            if (rt == null) return;
            Postorder((BinNode<TKey, TValue>)rt.LeftNode);
            Postorder((BinNode<TKey, TValue>)rt.RightNode);
            Console.WriteLine(rt.Key + " " + rt.Element);
        }

        public static void Inorder(BinNode<TKey, TValue> rt)
        {
            while (true)
            {
                if (rt == null) return;
                Inorder((BinNode<TKey, TValue>) rt.LeftNode);
                Console.WriteLine(rt.Key + " " + rt.Element);
                rt = (BinNode<TKey, TValue>) rt.RightNode;
            }
        }

        public static bool Search(BinNode<TKey, TValue> root, TKey key)
        {
            while (true)
            {
                if (root == null || Equals(root.Element, key))
                    return root != null;
                var left = Search(root._left, key);
                root = left ? root._left : root._right;
            }
        }
    }
    
    
}