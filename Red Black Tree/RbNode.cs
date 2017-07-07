namespace Red_Black_Tree
{
    public class RbNode<T> : INode<T>
    {
        public RbNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
            Colour = Colour.Red;
        }

        public T Value { get; set; }
        public Colour Colour { get; set; }
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }
        public INode<T> Parent { get; set; }
    }
}