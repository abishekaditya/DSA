namespace AVL_Tree
{
    public class AvlNode<T> : INode<T>
    {
        public AvlNode(T data)
        {
            Value = data;
            LNode = null;
            RNode = null;
            Height = 0;
        }
        public T Value { get; set; }
        public int Height { get; set; }
        public INode<T> LNode { get; set; }
        public INode<T> RNode { get; set; }
    }
}