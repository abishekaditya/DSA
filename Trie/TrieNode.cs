using List;

namespace Trie
{
    public class TrieNode<T>
    {
        public T Value { get; private set; }
        public LinkedList<TrieNode<T>> Children { get; private set; }
        public TrieNode<T> Parent { get; private set; }
        public int Depth { get; private set; }

        public TrieNode(T value, int depth, TrieNode<T> parent)
        {
            Value = value;
            Children = new LinkedList<TrieNode<T>>();
            Depth = depth;
            Parent = parent;
        }

        public bool IsLeaf => Children.Length == 0;

        public TrieNode<T> FindChildNode(T c)
        {
            for (Children.MoveToStart(); Children.Position < Children.Length; Children.Next())
            {
                if (Children.Value.Value.Equals(c)) return Children.Value;
            }
            return null;
        }

        public void DeleteChildNode(T c)
        {
            for (Children.MoveToStart(); Children.Position < Children.Length; Children.Next())
            {
                if (Children.Value.Value.Equals(c)) Children.Remove();
            }
        }
    }
}