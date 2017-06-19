namespace Dictionary
{
    public interface IDictionary<in TKey, TValue>
    {
        TValue this[TKey key] { get; set; }
        int Length { get; }
        void Clear();
        TValue Remove(TKey key);
        TValue RemoveAny();
    }
}