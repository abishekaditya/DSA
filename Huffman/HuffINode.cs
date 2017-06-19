namespace Huffman
{
    public class HuffINode : IHuffNode
    {
        public HuffINode(IHuffNode leftNode, IHuffNode rightNode, int weight)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
            Weight = weight;
        }

        public IHuffNode LeftNode { get; }
        public IHuffNode RightNode { get; }

        public bool Leaf => false;

        public int Weight { get; }


        public int CompareTo(object obj)
        {
            var item = (IHuffNode) obj;
            return item.Weight > Weight ? -1 : item.Weight == Weight ? 0 : 1;
        }
    }
}