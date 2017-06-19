using System;
using Link;

namespace Stack
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> _topLink;

        public LinkedStack()
        {
            Reset();
        }

        public void Clear()
        {
            Reset();
        }

        public void Push(T item)
        {
            _topLink = new Node<T>(item, _topLink);
            Length++;
        }

        public T Pop()
        {
            if (_topLink == null)
                throw new Exception("Empty Stack");
            var item = _topLink.Element;
            _topLink = _topLink.Next;
            Length--;
            return item;
        }

        public int Length { get; private set; }

        public T Top()
        {
            if (_topLink == null)
                throw new Exception("Empty Stack");
            return _topLink.Element;
        }

        private void Reset()
        {
            Length = 0;
            _topLink = null;
        }
    }
}