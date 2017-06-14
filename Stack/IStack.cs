namespace Stack
{
    public interface IStack<T>
    {
        void Clear();
        void Push(T item);
        T Pop();
        int Length { get; }
        T Top();
    }
}