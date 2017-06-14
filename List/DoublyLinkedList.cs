using Link;

namespace List
{
    public class DoublyLinkedList<T> : IList<T>
    {
        private DNode<T> _headNode;
        private DNode<T> _tailNode;
        protected DNode<T> CurrentNode;

        public DoublyLinkedList()
        {
            CurrentNode = _tailNode = _headNode = new DNode<T>(null, null);
            Length = 0;
        }

        public void Clear()
        {
            _headNode.Next = null;
            CurrentNode = _tailNode = _headNode = new DNode<T>(null, null);
            Length = 0;
        }

        public void Insert(T item)
        {
            CurrentNode.Next = new DNode<T>(item, CurrentNode, CurrentNode.Next);
            CurrentNode.Next.Next.Prev = CurrentNode.Next;
            Length++;
        }

        public void Append(T item)
        {
            _tailNode.Prev = new DNode<T>(item, _tailNode.Prev, _tailNode);
            _tailNode.Prev.Prev.Next = _tailNode.Prev;
            Length++;
        }

        public T Remove()
        {
            if (CurrentNode.Next == _tailNode) return default(T);
            var item = CurrentNode.Next.Element;
            CurrentNode.Next.Next.Prev = CurrentNode;
            CurrentNode.Next = CurrentNode.Next.Next;
            Length--;
            return item;
        }

        public void MoveToStart()
        {
            CurrentNode = _headNode;
        }

        public void MoveToEnd()
        {
            CurrentNode = _tailNode;
        }

        public void Previous()
        {
            if (CurrentNode != _headNode)
                CurrentNode = CurrentNode.Prev;
        }

        public void Next()
        {
            if (CurrentNode != _tailNode)
                CurrentNode = CurrentNode.Next;
        }

        public int Length { get; private set; }
        public int Position { get; set; }
        public T Value => CurrentNode.Next == null ? default(T) : CurrentNode.Next.Element;
    }
}