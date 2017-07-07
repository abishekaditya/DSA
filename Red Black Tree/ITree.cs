namespace Red_Black_Tree
{
    public interface ITree<in T>
    {
        bool IsEmpty { get; }

        void Clear();
        void Insert(T value);
        void Delete(T value);

        void Inorder();
        void Preorder();
        void Postorder();
    }
}