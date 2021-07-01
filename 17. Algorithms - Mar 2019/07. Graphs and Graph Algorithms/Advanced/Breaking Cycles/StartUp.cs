namespace Breaking_Cycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static SortedDictionary<char, List<char>> graph;

        public static void Main()
        {
            graph = new SortedDictionary<char, List<char>>();

            while (true)
            {
                var line = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var edgeParts = line.Split(' ');
                var node = edgeParts[0][0];
                var otherNodes = edgeParts.Skip(2).ToArray();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<char>();
                }

                graph[node].AddRange(otherNodes.Select(n => n[0]));
            }

            var result = new List<string>();

            foreach (var nodeKVP in graph)
            {
                var start = nodeKVP.Key;

                foreach (var end in graph[start].OrderBy(e => e))
                {
                    graph[start].Remove(end);
                    graph[end].Remove(start);

                    if (HasPath(start, end))
                    {
                        result.Add($"{start} - {end}");
                    }
                    else
                    {
                        graph[start].Add(end);
                        graph[end].Add(start);
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {result.Count}");
            result.ForEach(Console.WriteLine);
        }

        private static bool HasPath(char start, char end)
        {
            var queue = new Queue<char>();

            var visited = new HashSet<char>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);

                        if (child == end)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
