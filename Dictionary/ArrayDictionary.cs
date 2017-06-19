using List;

namespace Dictionary
{
    public class ArrayDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private const int DefaultSize = 10;
        private readonly ArrayList<KeyValuePair<TKey, TValue>> _list;

        public ArrayDictionary(int size)
        {
            _list = new ArrayList<KeyValuePair<TKey, TValue>>(size);
        }

        public ArrayDictionary() : this(DefaultSize)
        {
        }

        public void Clear()
        {
            _list.Clear();
        }

        public TValue this[TKey key]
        {
            get
            {
                for (_list.MoveToStart(); _list.Position < _list.Length; _list.Next())
                {
                    var temp = _list.Value;
                    if (key.Equals(temp.Key))
                        return temp.Value;
                }
                return default(TValue);
            }
            set => _list.Append(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue Remove(TKey key)
        {
            var tempValue = this[key];
            if (!tempValue.Equals(default(TValue)))
                _list.Remove();
            return tempValue;
        }

        public int Length => _list.Length;

        public TValue RemoveAny()
        {
            if (Length == 0) return default(TValue);
            _list.MoveToEnd();
            _list.Previous();
            var valuePair = _list.Remove();
            return valuePair.Value;
        }
    }
}