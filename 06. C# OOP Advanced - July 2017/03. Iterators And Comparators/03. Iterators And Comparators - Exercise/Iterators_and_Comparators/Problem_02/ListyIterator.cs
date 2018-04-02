using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    public ListyIterator(ICollection<T> collection)
    {
        this.Index = 0;
        this.Collection = new List<T>(collection);
    }

    public IReadOnlyList<T> Collection { get; private set; }

    private int Index { get; set; }

    public bool Move()
    {
        if (this.Index + 1 < this.Collection.Count)
        {
            this.Index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (this.Index == this.Collection.Count - 1)
        {
            return false;
        }

        return true;
    }

    public void Print()
    {
        if (!this.Collection.Any() || this.Index < 0 || this.Index > this.Collection.Count - 1)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.Collection[this.Index]);
    }

    public void PrintAll()
    {
        if (!this.Collection.Any() || this.Index < 0 || this.Index > this.Collection.Count - 1)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        foreach (T item in this.Collection)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Collection.Count; i++)
        {
            yield return this.Collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}