namespace Dictionary
{
    public interface IDictionary<in TKey, TValue>
    {
        void Clear();
        TValue this[TKey key] { get; set; }
        TValue Remove(TKey key);
        int Length { get; }
        TValue RemoveAny();
    }
}