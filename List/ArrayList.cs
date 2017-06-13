using System;

namespace List
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultSize = 10;
        private readonly int _maxSize;
        private int _curr;
        private readonly T[] _array;

        public ArrayList(int maxSize)
        {
            _maxSize = maxSize;
            Length = _curr = 0;
            _array = new T[maxSize];
        }

        public ArrayList() : this(DefaultSize) { }

        public void Clear()
        {
            Length = _curr = 0;
        }

        public void Insert(T item)
        {
            if (Length <= _maxSize)
            {
                for (var i = Length; i > _curr; i--)
                    _array[i] = _array[i - 1];
                _array[_curr] = item;
                Length++;
            }
            else
            {
                throw new Exception("List capacity exceeded");
            }
        }

        public void Append(T item)
        {
            if (Length <= _maxSize)
                _array[Length++] = item;
            else
                throw new Exception("List capacity exceeded");
        }

        public T Remove()
        {
            if ((_curr < 0) || (_curr >= Length)) return default(T);
            var item = _array[_curr];
            for (var i = _curr; i < Length - 1; i++)
                _array[i] = _array[i + 1];

            Length--;
            return item;
        }

        public void MoveToStart()
        {
            _curr = 0;
        }

        public void MoveToEnd()
        {
            _curr = Length;
        }

        public void Previous()
        {
            if (_curr != 0)
                _curr--;
        }

        public void Next()
        {
            if (_curr < Length)
                _curr++;
        }

        public int Length { get; private set; }

        public int Position
        {
            get => _curr;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _curr = (value >= 0) && (value <= Length) ? value : throw new Exception("Out of Range");
            }
        }

        public T Value => (_curr >= 0) && (_curr < Length) ? _array[_curr] : throw new Exception("No current element");
    }
}