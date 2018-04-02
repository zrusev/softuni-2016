using System.Collections;
using System.Collections.Generic;
public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Next { get; set; }

        public Node Previous { get; set; }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }

    public void Add(T element)
    {
        if (this.Count == 0)
        {
            this.Head = this.Tail = new Node(element);
        }
        else
        {
            var newTail = new Node(element) { Previous = this.Tail };
            this.Tail.Next = newTail;
            this.Tail = newTail;
        }

        this.Count++;
    }

    public bool Remove(T element)
    {
        if (this.Count == 0)
        {
            return false;
        }

        Node node = this.Head;
        Node currentNode = this.Head;
        Node previousNode = null;

        while (node != null)
        {
            currentNode = node;

            if (node.Value.Equals(element))
            {
                if (previousNode != null)
                {
                    previousNode.Next = currentNode.Next;
                }
                else
                {
                    this.Head = this.Head.Next;
                }

                break;
            }

            previousNode = currentNode;
            node = node.Next;
        }

        int count = 0;
        Node tempNode = this.Head;

        while (tempNode != null)
        {
            count++;
            tempNode = tempNode.Next;
        }

        if (this.Count > count)
        {
            this.Count--;
            return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}