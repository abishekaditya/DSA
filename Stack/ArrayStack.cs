using System;

namespace Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private const int DefaultSize = 10;
        public int MaxSize { get; }
        public T[] ListArray { get; }

        public ArrayStack(int size)
        {
            MaxSize = size;
            Length = 0;
            ListArray = new T[MaxSize];
        }

        public ArrayStack() : this(DefaultSize)
        {
        }

        public void Clear()
        {
            Length = 0;
        }

        public void Push(T item)
        {
            if (Length == MaxSize)
                throw new IndexOutOfRangeException();
            ListArray[Length++] = item;
        }

        public T Pop()
        {
            if (Length == 0)
                throw new Exception("Empty Stack");
            
            return ListArray[--Length];
        }

        public int Length { get; private set; }

        public T Top()
        {
            if (Length == 0)
                throw new Exception("Empty Stack");
            
            return ListArray[Length-1];
        }
    }
}
