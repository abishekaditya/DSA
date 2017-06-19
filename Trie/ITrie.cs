using List;

namespace Trie
{
    public interface ITrie<T, TPart>
    {
        TrieNode<TPart> Prefix(T value);
        bool Search(T value);
        void InsertRange(LinkedList<T> items);
        void Insert(T value);
        void Delete(T value);
    }
}