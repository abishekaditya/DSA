namespace Queue
{
    public interface IQueue<T>
    {
        void Clear();
        void Enqueue(T item);
        T Dequeue();
        T Front { get; }
        int Length { get; }
    }
}