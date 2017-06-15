using System;

namespace Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private const int DefaultSize = 10;
        private readonly int _maxSize;
        private int _front;
        private int _rear;
        private T[] _array;

        public ArrayQueue(int maxSize)
        {
            _maxSize = maxSize + 1;
            _front = 1;
            _rear = 0;
            _array = new T[_maxSize];
        }

        public ArrayQueue() : this(DefaultSize)
        {
        }

        public void Clear()
        {
            _rear = 0;
            _front = 1;
        }

        public void Enqueue(T item)
        {
            if ((_rear + 2) % _maxSize != _front )
                throw new IndexOutOfRangeException();
            _rear = (_rear + 1) % _maxSize;
            _array[_rear] = item;
        }

        public T Dequeue()
        {
            if (Length == 0)
                throw new Exception("Queue Empty");
            var item = _array[_front];
            _front = (_front + 1) % _maxSize;
            return item;
        }

        public T Front
        {
            get
            {
                if (Length == 0)
                    throw new Exception("Queue Empty");
                return _array[_front];
            }
        }

        public int Length => ((_rear + _maxSize) - _front + 1) % _maxSize;
    }
}