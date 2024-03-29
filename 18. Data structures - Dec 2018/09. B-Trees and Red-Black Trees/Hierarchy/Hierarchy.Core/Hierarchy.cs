﻿namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node root;
        private Dictionary<T, Node> nodesByValue;

        public Hierarchy(T root)
        {
            this.root = new Node(root);
            this.nodesByValue = new Dictionary<T, Node> { { root, this.root } };
        }

        public int Count
            => this.nodesByValue.Count;

        public void Add(T parent, T child)
        {
            if (!this.nodesByValue.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            if (this.nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node parentNode = this.nodesByValue[parent];
            Node childNode = new Node(child, parentNode);

            parentNode.Children.Add(childNode);
            this.nodesByValue.Add(child, childNode);
        }

        public void Remove(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            Node current = this.nodesByValue[element];
            if (current.Parent == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var currentChild in current.Children)
            {
                currentChild.Parent = current.Parent;
                current.Parent.Children.Add(currentChild);
            }
            
            current.Parent.Children.Remove(current);
            this.nodesByValue.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.nodesByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            Node parent = this.nodesByValue[item];

            return parent.Children.Select(x => x.Value);
        }

        public T GetParent(T item)
        {
            if (!this.nodesByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            Node child = this.nodesByValue[item];

            return child.Parent != null 
                ? child.Parent.Value 
                : default(T);
        }

        public bool Contains(T value)
            => this.nodesByValue.ContainsKey(value);

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            HashSet<T> result = new HashSet<T>(this.nodesByValue.Keys);
            result.IntersectWith(new HashSet<T>(other.nodesByValue.Keys));

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            Node current = this.root;
            queue.Enqueue(current);

            while (queue.Count > 0 )
            {
                current = queue.Dequeue();
                yield return current.Value;

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        
        private class Node
        {
            public Node Parent { get; set; }

            public T Value { get; set; }

            public List<Node> Children { get; set; }

            public Node(T value, Node parent = null)
            {
                this.Value = value;
                this.Children = new List<Node>();
                this.Parent = parent;
            }
        }
    }
}