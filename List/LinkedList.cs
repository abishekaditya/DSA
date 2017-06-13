using System;
using Link;
namespace List
{

    public class LinkedList<T> : IList<T>
    {
        private Node<T> _headNode;
        private Node<T> _tailNode;
        protected Node<T> CurrentNode;

        public LinkedList()
        {
            CurrentNode = _tailNode = _headNode = new Node<T>(null);
            Length = 0;
        }

        public void Clear()
        {
            _headNode.Next = null;
            CurrentNode = _tailNode = _headNode = new Node<T>(null);
            Length = 0;
        }

        public void Insert(T item)
        {
            CurrentNode.Next = new Node<T>(item, CurrentNode.Next);
            if (_tailNode == CurrentNode)
            {
                _tailNode = CurrentNode.Next;
            }
            Length++;
        }

        public void Append(T item)
        {
            _tailNode = _tailNode.Next = new Node<T>(item, null);
            Length++;
        }

        public T Remove()
        {
            if (CurrentNode.Next == null)
                return default(T);
            var item = CurrentNode.Next.Element;
            if (_tailNode == CurrentNode.Next) _tailNode = CurrentNode;
            CurrentNode.Next = CurrentNode.Next.Next;
            Length--;
            return item;
        }

        public void MoveToStart()
        {
            CurrentNode = _headNode;
        }

        public void MoveToEnd()
        {
            CurrentNode = _tailNode;
        }

        public void Previous()
        {
            if (CurrentNode == _headNode) return;
            var tempNode = _headNode;
            while (tempNode.Next != CurrentNode)
                tempNode = tempNode.Next;
            CurrentNode = tempNode;
        }

        public void Next()
        {
            if (CurrentNode != _tailNode) CurrentNode = CurrentNode.Next;
        }

        public int Length { get; private set; }

        public int Position
        {
            get
            {
                var tempNode = _headNode;
                int index;
                for (index = 0; CurrentNode != tempNode; index++)
                    tempNode = tempNode.Next;
                return index;
            }
            set
            {
                if (value <= 0 && value > Length)
                {
                    throw new IndexOutOfRangeException();
                }
                CurrentNode = _headNode;
                for (var i = 0; i < value; i++)
                {
                    CurrentNode = CurrentNode.Next;
                }
            }
        }

        public T Value => CurrentNode.Next == null ? default(T) : CurrentNode.Next.Element;
    }
}