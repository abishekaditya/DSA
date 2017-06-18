
namespace AVL_Tree
{
    public interface INode<T>
    {
        T Value { get; set; }
        int Height { get; set; }
        INode<T> LNode { get; set; }
        INode<T> RNode { get; set; }
    }
}