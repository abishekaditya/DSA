namespace Queue
{
    public interface IQueue<T>
    {
        T Front { get; }
        int Length { get; }
        void Clear();
        void Enqueue(T item);
        T Dequeue();
    }
}