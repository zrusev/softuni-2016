using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }
    public Node Head { get; private set; }
    public Node Tail { get; private set; }

    public void AddFirst(T item)
    {
        Node oldNode = this.Head;

        this.Head = new Node(item);
        this.Head.Next = oldNode;

        if (this.Count == 0)
        {
            this.Tail = this.Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node oldNode = this.Tail;

        this.Tail = new Node(item);

        if (this.Count == 0)
        {
            this.Head = this.Tail;
        }
        else
        {
            oldNode.Next = this.Tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T item = this.Head.Value;

        this.Head = this.Head.Next;

        this.Count--;

        if (this.Count == 0)
        {
            this.Tail = null;
        }

        return item;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T item = this.Tail.Value;

        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            Node newTail = this.GetSecondToLast();
            newTail.Next = null;
            this.Tail = newTail;
        }

        this.Count--;

        return item;
    }

    private Node GetSecondToLast()
    {
        Node currentNode = this.Head;

        while (currentNode.Next != this.Tail)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = this.Head;
        
        while (currentNode.Next != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public class Node
    {
        public T Value { get; set; }

        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
