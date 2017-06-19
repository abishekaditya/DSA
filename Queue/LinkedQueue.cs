using System;
using Link;

namespace Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> _frontNode;
        private Node<T> _rearNode;

        public LinkedQueue()
        {
            _rearNode = _frontNode = new Node<T>(null);
            Length = 0;
        }

        public void Clear()
        {
            _rearNode = _frontNode = new Node<T>(null);
            Length = 0;
        }

        public void Enqueue(T item)
        {
            _rearNode.Next = new Node<T>(item, new Node<T>(null));
            _rearNode = _rearNode.Next;
            Length++;
        }

        public T Dequeue()
        {
            if (Length == 0)
                throw new Exception("Queue Empty");
            var item = _frontNode.Next.Element;
            _frontNode.Next = _frontNode.Next.Next;
            if (_frontNode.Next == null)
                _frontNode = _rearNode;
            Length--;
            return item;
        }

        public T Front
        {
            get
            {
                if (Length == 0)
                    throw new Exception("Queue Empty");
                return _frontNode.Next.Element;
            }
        }

        public int Length { get; private set; }
    }
}