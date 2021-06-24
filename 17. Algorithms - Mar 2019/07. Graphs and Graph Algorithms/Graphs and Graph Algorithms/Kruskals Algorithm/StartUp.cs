namespace Kruskals_Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class StartUp
    {
        static int[] parents;

        private static int FindRoot(int node)
        {
            while (parents[node] != node)
            {
                node = parents[node];
            }

            return node;
        }

        public static void Main()
        {
            var graph = new List<Edge>
            {
                new Edge { First = 2, Second = 4, Weight = 2 },
                new Edge { First = 1, Second = 4, Weight = 9 },
                new Edge { First = 3, Second = 5, Weight = 7 },
                new Edge { First = 4, Second = 5, Weight = 8 },
                new Edge { First = 8, Second = 9, Weight = 7 },
                new Edge { First = 1, Second = 2, Weight = 4 },
                new Edge { First = 5, Second = 6, Weight = 12 },
                new Edge { First = 7, Second = 8, Weight = 8 },
                new Edge { First = 7, Second = 9, Weight = 10 },
                new Edge { First = 1, Second = 3, Weight = 5 },
                new Edge { First = 3, Second = 4, Weight = 20 }
            };

            var nodes = graph
                .Select(e => e.First)
                .Union(graph.Select(e => e.Second))
                .Distinct()
                .ToHashSet();

            parents = new int[nodes.Max() + 1];

            foreach (var node in nodes)
            {
                parents[node] = node;
            }

            //var edges = new SortedSet<Edge>(
            //    Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            var edges = graph.OrderBy(e => e.Weight).ToHashSet();

            graph.ForEach(e => edges.Add(e));

            while (edges.Count != 0)
            {
                //var edge = edges.Min;
                var edge = edges.First();
                edges.Remove(edge);

                var firstNode = edge.First;
                var secondNode = edge.Second;

                var firstRoot = FindRoot(firstNode);
                var secondRoot = FindRoot(secondNode);

                if (firstRoot != secondRoot)
                {
                    Console.WriteLine($"{firstNode} - {secondNode}");
                    parents[firstRoot] = secondRoot;
                }
            }
        }
    }
}
