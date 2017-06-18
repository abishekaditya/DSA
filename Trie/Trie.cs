using System;
using List;

namespace Trie
{
    public class Trie : ITrie<string,char>
    {
        public Trie()
        {
            Root = new TrieNode<char>('^', 0, null);
        }

        public TrieNode<char> Root { get; }

        public TrieNode<char> Prefix(string s)
        {
            var currentNode = Root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public bool Search(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
        }

        public void InsertRange(LinkedList<string> items)
        {
            for (items.MoveToStart(); items.Position < items.Length; items.Next())
                Insert(items.Value);
        }

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new TrieNode<char>(s[i], current.Depth + 1, current);
                current.Children.Insert(newNode);
                current = newNode;
            }

            current.Children.Insert(new TrieNode<char>('$', current.Depth + 1, current));
        }

        public void Delete(string s)
        {
            if (!Search(s)) return;
            var node = Prefix(s).FindChildNode('$');

            while (node.IsLeaf)
            {
                var parent = node.Parent;
                parent.DeleteChildNode(node.Value);
                node = parent;
            }
        }
    }
}