using System;

public class ArrayList<T>
{
    private const int DEFAULT_LENGTH = 2;

    private T[] data;

    public int Count { get; private set; }

    public ArrayList()
    {
        this.data = new T[DEFAULT_LENGTH];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.data[index];
        }

        set
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.data[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.data.Length)
        {
            this.Resize();
        }

        this.data[this.Count++] = item;
    }

    private void Resize()
    {
        T[] newArray = new T[this.Count * 2];
        Array.Copy(this.data, newArray, this.Count);
        this.data = newArray;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T item = this.data[index];

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.Count--;

        if (this.Count <= this.data.Length / 4)
        {
            this.Srink();
        }

        return item;
    }

    private void Srink()
    {
        T[] newArray = new T[this.data.Length / 2];

        Array.Copy(this.data, newArray, this.Count);

        this.data = newArray;
    }
}
