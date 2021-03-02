namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public PriorityQueue()
            => this._elements = new List<T>();

        public int Size => this._elements.Count;

        public T Dequeue()
        {
            var firstElement = this.Peek();
            this.Swap(0, this.Size - 1);
            this._elements.RemoveAt(this.Size - 1);

            this.HeapifyDown();

            return firstElement;
        }

        public void Add(T element)
        {
            this._elements.Add(element);

            this.HeapifyUp();
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._elements[0];
        }

        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = this.GetLeftChildIndex(0);

            while (this.IndexIsValid(leftChildIndex) 
                && this.IsLess(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);

                if (this.IndexIsValid(rightChildIndex) 
                    && this.IsLess(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }

                this.Swap(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = this.GetLeftChildIndex(index);
            }
        }

        private void HeapifyUp()
        {
            var currentIndex = this.Size - 1;
            var parentIndex = this.GetParentIndex(currentIndex);

            while (this.IndexIsValid(currentIndex)
                && this.IsGreater(currentIndex, parentIndex))
            {
                this.Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = this.GetParentIndex(currentIndex);

            }
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            var temp = this._elements[currentIndex];
            this._elements[currentIndex] = this._elements[parentIndex];
            this._elements[parentIndex] = temp;
        }

        private bool IsGreater(int childIndex, int parentIndex)
            => this._elements[childIndex].CompareTo(this._elements[parentIndex]) > 0;

        private bool IsLess(int childIndex, int parentIndex)
            => this._elements[childIndex].CompareTo(this._elements[parentIndex]) < 0;

        private int GetParentIndex(int childIndex)
            => (childIndex - 1) / 2;

        private int GetLeftChildIndex(int parentIndex)
            => 2 * parentIndex + 1;

        private int GetRightChildIndex(int parentIndex)
            => 2 * parentIndex + 2;

        private bool IndexIsValid(int index)
            => index < this.Size;

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Max heap is empty!");
            }
        }

    }
}
