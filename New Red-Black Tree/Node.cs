namespace New_Red_Black_Tree
{
    internal class Node<T>
    {
        public Node(T value, Colour colour, int size)
        {
            Value = value;
            Colour = colour;
            Size = size;
        }

        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }
        public int Size { get; set; }
        public Colour Colour { get; set; }
    }
}