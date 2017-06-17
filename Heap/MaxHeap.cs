using System;
using static Utilities.Utilities;

namespace Heap
{
    public class MaxHeap<T> where T : IComparable
    {
        private readonly T[] _heap;
        private readonly int _maxSize;
        public int Size { get; private set; }

        public MaxHeap(T[] heap, int maxSize)
        {
            _heap = heap;
            _maxSize = maxSize;
            Size = heap.Length;
            BuildHeap();
        }

        public void BuildHeap()
        {
            for (var i = Size / 2 - 1; i >= 0; i--)
                SiftDown(i);
        }

        private void SiftDown(int pos)
        {
            if (pos < 0 && pos >= Size)
            {
                throw new Exception("Illegal Position");
            }
            while (!IsLeaf(pos))
            {
                var temp = LeftChild(pos);
                if (temp < (Size -1) && _heap[temp].CompareTo(_heap[temp + 1]) < 0)
                {
                    temp++;
                }
                if (_heap[pos].CompareTo((_heap[temp])) >= 0)
                {
                    return;
                }
                Swap(_heap,pos,temp);
                pos = temp;

            }
        }

        private bool IsLeaf(int pos)
        {
            return (pos >= Size / 2) && (pos < Size);
        }

        private int LeftChild(int pos)
        {
            if (pos >= Size/2)
                throw new Exception("No Left Child Present");
            return 2 * pos + 1;
        }

        public int RightChild(int pos)
        {
            if (pos >= (Size - 1) / 2)
                throw new Exception("No Right Child Present");
            return 2 * pos + 2;
        }

        private int Parent(int pos)
        {
            if (pos <= 0)
                throw new Exception("Has no parent");
            return (pos - 1) / 2;
        }

        public void Insert(T value)
        {
            if (Size >= _maxSize)
                throw new Exception("Heap is Full");
            var curr = Size++;
            _heap[curr] = value;
            while ((curr != 0) && (_heap[curr].CompareTo(_heap[Parent(curr)]) > 0))
            {
                Swap(_heap,curr,Parent(curr));
                curr = Parent(curr);
            }
        }

        public T RemoveMax()
        {
            if (Size <= 0)
                throw new Exception("Empty Heap");
            Swap(_heap, 0 , --Size);
            if (Size != 0)
                SiftDown(0);
            return _heap[Size];
        }

        public T Remove(int pos)
        {
            if (pos < 0 && pos >= Size)
                throw new Exception("Illegal Position");
            if (pos == Size - 1)
                Size--;
            else
            {
                Swap(_heap, pos, --Size);
                while (pos > 0 && (_heap[pos].CompareTo(_heap[Parent(pos)]) > 0))
                {
                    Swap(_heap, pos, Parent(pos));
                    pos = Parent(pos);
                }
                if (Size != 0) SiftDown(pos);
            }
            return _heap[Size];
        }

        public void Print()
        {
            for (var i = 0; i < Size; i++)
            {
                Console.Write(_heap[i] + " ");
            }
            Console.WriteLine();
        }
        
    }
}