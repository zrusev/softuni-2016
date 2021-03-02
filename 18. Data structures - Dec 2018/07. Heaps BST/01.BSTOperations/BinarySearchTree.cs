namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
            => this.Copy(root);

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => throw new NotImplementedException();

        public bool Contains(T element)
        {
            Node<T> current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if(this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            Node<T> toInsert = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                this.InsertElementDfs(this.Root, null, toInsert);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            Node<T> current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        public void EachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public List<T> Range(T lower, T upper)
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public int GetRank(T element)
        {
            throw new NotImplementedException();
        }

        private void Copy(Node<T> current)
        {
            if (current != null)
            {
                this.Insert(current.Value);
                this.Copy(current.LeftChild);
                this.Copy(current.RightChild);
            }
        }

        private void InsertElementDfs(
            Node<T> current, 
            Node<T> previous, 
            Node<T> toInsert)
        {
            if (current == null
                && this.IsLess(toInsert.Value, previous.Value))
            {
                previous.LeftChild = toInsert;
                if (this.LeftChild == null)
                {
                    return;
                }
            }

            if (current == null
                && this.IsGreater(toInsert.Value, previous.Value))
            {
                previous.RightChild = toInsert;
                if (this.RightChild == null)
                {
                    return;
                }
            }

            if (this.IsLess(toInsert.Value, current.Value))
            {
                this.InsertElementDfs(current.LeftChild, current, toInsert);
            }
            else if(this.IsGreater(toInsert.Value, current.Value))
            {
                this.InsertElementDfs(current.RightChild, current, toInsert);
            }
        }

        private bool IsLess(T firstElement, T secondElement)
            => firstElement.CompareTo(secondElement) < 0;

        private bool IsGreater(T firstElement, T secondElement)
            => firstElement.CompareTo(secondElement) > 0;
        private bool AreEqual(T firstElement, T secondElement)
            => firstElement.CompareTo(secondElement) == 0;
    }
}
