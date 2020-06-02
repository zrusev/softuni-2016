using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; private set; }

    public List<Tree<T>> Children { get; private set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public void Print(int indent = 0)
    {
        this.Print(this, indent);
    }

    private void Print(Tree<T> node, int indent)
    {
        Console.WriteLine($"{new string(' ', indent)}{node.Value}");

        foreach (Tree<T> child in node.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> node, List<T> result)
    {
        foreach (Tree<T> child in node.Children)
        {
            this.DFS(child, result);
        }

        result.Add(node.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        throw new NotImplementedException();
    }
}
