using Utilities;
namespace AVL_Tree
{
    public class AvlNode<T> : INode<T>
    {
        public AvlNode(T data)
        {
            Value = data;
            Left = null;
            Right = null;
            Height = 1;
        }
        public T Value { get; set; }
        public int Height { get; set; }
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }
        public INode<T> Parent { get; set; }

        public void ComputeHeight()
        {
            Height = 1;
            if (Left != null && Right != null)
                Height += Utilities.Utilities.Max(Left.Height, Right.Height);
            else
            {
                if (Left != null)
                    Height += Left.Height;
                if (Right != null)
                    Height += Right.Height;
            }
        }

        public int GetBalance()
        {
            var balance = 0;
            if (Left != null)
                balance += Left.Height;
            if (Right != null)
            {
                balance -= Right.Height;
            }
            return balance;
        }

        public INode<T> Balance()
        {
            ComputeHeight();
            var balance = GetBalance();

            if (balance > 1)
            {
                if (Left.GetBalance() < 0)
                {
                    Left = Left.RotateRight();
                }
                return RotateRight();
            } else if (balance < -1)
            {
                if (Right.GetBalance() > 0)
                {
                    Right = Right.RotateRight();
                }
                return RotateLeft();
            }
            return this;
        }
        
        public INode<T> RotateRight()
        {
            var temp = Left;
            Left = temp.Right;
            ComputeHeight();
            temp.Right = this;
            temp.ComputeHeight();
            temp.Parent = Parent;
            return temp;
        }


        public INode<T> RotateLeft()
        {
            var temp = Right;
            Right = temp.Left;
            ComputeHeight();
            temp.Left = this;
            temp.ComputeHeight();
          //temp.Parent = this.Parent;
            return temp;
        }
    }
}