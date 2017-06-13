namespace Link
{
    public class Node<T>
    {
        public Node(T element, Node<T> next)
        {
            Element = element;
            Next = next;
        }

        public Node(Node<T> next)
        {
            Next = next;
        }

        public T Element { get; private set; }
        public Node<T> Next { get; set; }
    }
}
