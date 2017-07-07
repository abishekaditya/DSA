using System;

namespace BTree
{
    public class BNode<T> where T : IComparable
    {
        public readonly BNode<T>[] Children;
        public readonly T[] Keys;
        public int NumKeys;

        public BNode(int size, bool leaf)
        {
            Keys = new T[2 * size - 1];
            Size = size;
            Children = new BNode<T>[2 * size];
            NumKeys = 0;
            Leaf = leaf;
        }

        private int Size { get; }
        public bool Leaf { get; }

        public void Traverse()
        {
            int i;
            for (i = 0; i < NumKeys; i++)
            {
                if (!Leaf) Children[i].Traverse();
                Console.Write(Keys[i] + " ");
            }

            if (!Leaf) Children[i].Traverse();
        }

        public BNode<T> Search(T key)
        {
            var i = 0;
            while (i < NumKeys && key.CompareTo(Keys[i]) > 0)
                i++;

            return Keys[i].Equals(key) ? null : Children[i].Search(key);
        }

        public void InsertNonFull(T key)
        {
            var i = NumKeys - 1;

            if (Leaf)
            {
                while (i >= 0 && Keys[i].CompareTo(key) > 0)
                {
                    Keys[i + 1] = Keys[i];
                    i--;
                }

                Keys[i + 1] = key;
                NumKeys += 1;
            }
            else
            {
                while (i >= 0 && Keys[i].CompareTo(key) > 0)
                    i--;

                if (Children[i + 1].NumKeys == 2 * Size - 1)
                {
                    SpiltChild(i + 1, Children[i + 1]);
                    if (Keys[i + 1].CompareTo(key) < 0)
                        i++;
                }
                Children[i + 1].InsertNonFull(key);
            }
        }

        public void SpiltChild(int i, BNode<T> node)
        {
            var newNode = new BNode<T>(node.Size, node.Leaf) {NumKeys = Size - 1};

            for (var j = 0; j < Size - 1; j++)
                newNode.Keys[j] = node.Keys[j + Size];


            if (!node.Leaf)
                for (var j = 0; j < Size; j++)
                    newNode.Children[j] = node.Children[j + Size];
            node.NumKeys = Size - 1;

            for (var j = NumKeys; j >= i + 1; j--)
                Children[j + 1] = Children[j];

            Children[i + 1] = newNode;

            for (var j = NumKeys - 1; j >= i; j--)
                Keys[j + 1] = Keys[j];

            Keys[i] = node.Keys[Size - 1];
            NumKeys += 1;
        }

        private int FindKey(T key)
        {
            var id = 0;
            while (id < NumKeys && Keys[id].CompareTo(key) < 0)
                ++id;
            return id;
        }

        public void Remove(T key)
        {
            var id = FindKey(key);

            if (id < NumKeys && Keys[id].Equals(key))
            {
                if (Leaf)
                    RemoveFromLeaf(id);
                else
                    RemoveFromNonLeaf(id);
            }
            else
            {
                if (Leaf)
                    return;

                var flag = id == NumKeys;

                if (Children[id - 1].NumKeys < Size)
                    Fill(id);

                if (flag && id > NumKeys)
                    Children[id - 1].Remove(key);
                else
                    Children[id].Remove(key);
            }
        }

        private void Fill(int id)
        {
            if (id != 0 && Children[id - 1].NumKeys >= Size)
            {
                BorrowFromPrev(id);
            }
            else if (id != NumKeys && Children[id + 1].NumKeys >= Size)
            {
                BorrowFromSucc(id);
            }
            else
            {
                if (id != NumKeys)
                    Merge(id);
                else
                    Merge(id - 1);
            }
        }

        private void BorrowFromPrev(int id)
        {
            var child = Children[id];
            var sibling = Children[id - 1];

            for (var i = child.NumKeys - 1; i >= 0; --i)
                child.Keys[i + 1] = child.Keys[i];

            if (!child.Leaf)
                for (var i = child.NumKeys; i > 0; --i)
                    child.Children[i + 1] = child.Children[i];

            child.Keys[0] = Keys[id - 1];

            if (!Leaf)
                child.Children[0] = sibling.Children[sibling.NumKeys];

            Keys[id - 1] = sibling.Keys[sibling.NumKeys - 1];

            child.NumKeys += 1;
            sibling.NumKeys -= 1;
        }


        private void BorrowFromSucc(int id)
        {
            var child = Children[id];
            var sibling = Children[id + 1];

            child.Keys[child.NumKeys] = Keys[id];

            if (!child.Leaf)
                child.Children[child.NumKeys + 1] = sibling.Children[0];

            Keys[id] = sibling.Keys[0];

            for (var i = 1; i < sibling.NumKeys; ++i)
                sibling.Keys[i - 1] = sibling.Keys[i];

            if (!Leaf)
                child.Children[0] = sibling.Children[sibling.NumKeys];

            if (!sibling.Leaf)
                for (var i = 1; i < sibling.NumKeys; ++i)
                    sibling.Children[i - 1] = sibling.Children[i];
            child.NumKeys += 1;
            sibling.NumKeys -= 1;
        }

        private void RemoveFromNonLeaf(int id)
        {
            var key = Keys[id];

            if (Children[id].NumKeys >= Size)
            {
                var pred = GetPred(id);
                Keys[id] = pred;
                Children[id].Remove(pred);
            }
            else if (Children[id + 1].NumKeys == Size)
            {
                var succ = GetSucc(id);
                Keys[id] = succ;
                Children[id].Remove(succ);
            }
            else
            {
                Merge(id);
                Children[id].Remove(key);
            }
        }

        private void Merge(int id)
        {
            var child = Children[id];
            var sibling = Children[id + 1];

            child.Keys[Size - 1] = Keys[id];

            for (var i = 0; i < sibling.NumKeys; ++i)
                child.Keys[i + Size] = sibling.Keys[i];

            if (!child.Leaf)
                for (var i = 0; i < sibling.NumKeys; ++i)
                    child.Children[i + Size] = sibling.Children[i];

            for (var i = id + 1; i < NumKeys; ++i)
                Keys[i - 1] = Keys[i];

            for (var i = id + 2; i <= NumKeys; ++i)
                Children[i - 1] = Children[i];

            child.NumKeys += sibling.NumKeys;
            NumKeys--;
        }

        private T GetPred(int id)
        {
            var curr = Children[id + 1];
            while (!curr.Leaf)
                curr = curr.Children[curr.NumKeys];
            return curr.Keys[curr.NumKeys - 1];
        }

        private T GetSucc(int id)
        {
            var curr = Children[id + 1];
            while (!curr.Leaf)
                curr = curr.Children[0];
            return curr.Keys[0];
        }


        private void RemoveFromLeaf(int id)
        {
            for (var i = id + 1; i < NumKeys; i++)
                Keys[i - 1] = Keys[i];
            NumKeys--;
        }
    }
}