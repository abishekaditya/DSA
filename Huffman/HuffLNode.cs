namespace Huffman
{
    public class HuffLNode<T> : IHuffNode
    {
        public HuffLNode(T elem, int weight)
        {
            Weight = weight;
            Element = elem;
        }

        public T Element { get; }
        public int Weight { get; }

        public bool Leaf => true;

        public int CompareTo(object obj)
        {
            var item = (IHuffNode) obj;
            return item.Weight > Weight ? -1 : item.Weight == Weight ? 0 : 1;
        }
    }
}