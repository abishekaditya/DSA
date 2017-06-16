namespace Link
{
    public interface IBNode<T>
    {
        T Element { get; set; }
        IBNode<T> LeftNode { get; set; }
        IBNode<T> RightNode { get; set; }
        bool IsLeaf { get; }
    }
}