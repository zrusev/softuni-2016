using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node root;

    private BinarySearchTree(Node node)
    {
        this.root = node;
    }

    public void Insert(T value)
    {
        this.root = this.Insert(this.root, value);

        //if (this.root == null)
        //{
        //    this.root = new Node(value);
        //    return;
        //}

        //Node parent = null;
        //Node current = this.root;

        //while (current != null)
        //{
        //    int compare = current.Value.CompareTo(value);

        //    if (compare > 0)
        //    {
        //        parent = current;
        //        current = current.Left;
        //    }
        //    else if(compare < 0)
        //    {
        //        parent = current;
        //        current = current.Right;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        //Node newNode = new Node(value);

        //if (parent.Value.CompareTo(value) > 0)
        //{
        //    parent.Left = newNode;
        //}
        //else
        //{
        //    parent.Right = newNode;
        //}
    }

    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        int compare = node.Value.CompareTo(value);

        if (compare > 0)
        {
            node.Left = this.Insert(node.Left, value);
        }
        else if(compare < 0)
        {
            node.Right = this.Insert(node.Right, value);
        }

        return node;
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(value);

            if (compare > 0)
            {
                current = current.Left;
            }
            else if(compare < 0)
            {
                current = current.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        throw new NotImplementedException();
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int compare = current.Value.CompareTo(item);
            if (compare > 0)
            {
                current = current.Left;
            }
            else if(compare < 0)
            {
                current = current.Right;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        
        action(node.Value);

        this.EachInOrder(node.Right, action);

    }

    private class Node
    {
        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
}

public class Launcher
{
    public static void Main()
    {
        BinarySearchTree<int> BST = new BinarySearchTree<int>();

        BST.Insert(20);
        BST.Insert(16);
        BST.Insert(17);
        BST.Insert(28);
        BST.Insert(14);
        BST.Insert(29);
        BST.Insert(29);
    }
}
