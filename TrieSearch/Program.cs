using System;
using List;

namespace TrieSearch
{
    internal static class Program
    {
        private static void Main()
        {
            var trie = new Trie.Trie();
            trie.Insert("abc");
            trie.Insert("abcd");
            trie.Insert("cde");
            Console.WriteLine("String " + (trie.Search("abcd") ? "Found" : "Not Found"));
            Console.ReadLine();
        }
    }
}
