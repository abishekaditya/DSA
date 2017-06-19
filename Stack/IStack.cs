namespace Stack
{
    public interface IStack<T>
    {
        int Length { get; }
        void Clear();
        void Push(T item);
        T Pop();
        T Top();
    }
}