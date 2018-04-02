using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private List<T> data;

    public Stack()
    {
        this.data = new List<T>();
    }

    public void Push(T item)
    {
        this.data.Add(item);
    }

    public T Pop()
    {
        if (!this.data.Any())
        {
            throw new ArgumentException("No elements");
        }

        T lastItem = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);

        return lastItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}