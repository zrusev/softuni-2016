namespace Prims_Algorithm
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    public class StartUp
    {
        static List<Edge> graph = new List<Edge>();
        static Dictionary<int, List<Edge>> nodeToEdges = new Dictionary<int, List<Edge>>();
        static HashSet<int> spanningTree = new HashSet<int>();

        private static void Prim(int startingNode)
        {
            spanningTree.Add(startingNode);

            var priorityQueue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            priorityQueue.AddMany(nodeToEdges[startingNode]);

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.GetFirst();
                priorityQueue.Remove(minEdge);

                var firstNode = minEdge.First;
                var secondNode = minEdge.Second;

                var nonTreeNode = -1;

                if (spanningTree.Contains(firstNode) &&
                    !spanningTree.Contains(secondNode))
                {
                    nonTreeNode = secondNode;
                }


                if (spanningTree.Contains(secondNode) &&
                    !spanningTree.Contains(firstNode))
                {
                    nonTreeNode = firstNode;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                spanningTree.Add(nonTreeNode);

                Console.WriteLine($"{minEdge.First} - {minEdge.Second}");

                priorityQueue.AddMany(nodeToEdges[nonTreeNode]);
            }
        }

        public static void Main()
        {
            graph = new List<Edge>
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

            foreach (var edge in graph)
            {
                if (!nodeToEdges.ContainsKey(edge.First))
                {
                    nodeToEdges[edge.First] = new List<Edge>();
                }

                if (!nodeToEdges.ContainsKey(edge.Second))
                {
                    nodeToEdges[edge.Second] = new List<Edge>();
                }

                nodeToEdges[edge.First].Add(edge);
                nodeToEdges[edge.Second].Add(edge);
            }

            foreach (var node in nodes)
            {
                if (!spanningTree.Contains(node))
                {
                    Prim(node);
                }
            }

        }
    }
}