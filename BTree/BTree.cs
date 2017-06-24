using System;

namespace BTree
{
    public class BTree<T> where T : IComparable
    {
        private BNode<T> _root;
        private readonly int _size;

        public BTree(int s)
        {
            _root = null;
            _size = s;
        }

        public void Print()
        {
            _root?.Traverse();
        }

        public BNode<T> Search(T key)
        {
            return _root?.Search(key);
        }

        public void Insert(T key)
        {
            if (_root == null)
            {
                _root = new BNode<T>(_size, true)
                {
                    Keys = {[0] = key},
                    NumKeys = 1
                };
            }
            else
            {
                if (_root.NumKeys == 2*_size-1)
                {
                    var s = new BNode<T>(_size, false) {Children = {[0] = _root}};

                    s.SpiltChild(0, _root);

                    var i = 0;
                    if (s.Keys[0].CompareTo(key) < 0)
                        i++;

                    s.Children[i].InsertNonFull(key);
                    _root = s;
                }
                else
                    _root.InsertNonFull(key);
            }
        }
    }
}