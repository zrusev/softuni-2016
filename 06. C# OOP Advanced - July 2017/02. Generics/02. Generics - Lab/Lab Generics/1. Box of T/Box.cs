
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private IList<T> data;
    public Box()
    {
        this.data = new List<T>();
    }

    public int Count => this.data.Count;

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        var rem = data.LastOrDefault();
        data.RemoveAt(data.Count - 1);
        return rem;
    }
}