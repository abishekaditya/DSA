namespace Link
{
    public class DNode<T>
    {
       

        public DNode(T item, DNode<T> prevNode, DNode<T> nextNode)
        {
            Element = item;
            Prev = prevNode;
            Next = nextNode;
        }

        public DNode(DNode<T> prevNode, DNode<T> nextNode)
        {
            Prev = prevNode;
            Next = nextNode;
        }

        public DNode<T> Next { get; set; }
        public DNode<T> Prev { get; set; }
        public T Element { get; set; }
    }
}