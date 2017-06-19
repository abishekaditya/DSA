namespace AVL_Tree
{
    public interface INode<T>
    {
        T Value { get; set; }
        int Height { get; set; }
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        INode<T> Parent { get; set; }
        void ComputeHeight();
        int GetBalance();
        INode<T> RotateRight();
        INode<T> RotateLeft();
        INode<T> Balance();
    }
}