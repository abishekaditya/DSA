namespace List
{
    public interface IList<T>
    {
        int Length { get; }
        int Position { get; set; }

        T Value { get; }
        void Clear();
        void Insert(T item);
        void Append(T item);
        T Remove();
        void MoveToStart();
        void MoveToEnd();
        void Previous();
        void Next();
    }
}