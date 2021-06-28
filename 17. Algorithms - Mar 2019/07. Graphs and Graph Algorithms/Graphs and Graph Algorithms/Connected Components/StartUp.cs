namespace Connected_Components
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static bool[] visited;
        static List<int>[] graph;

        private class Node
        {
            public int Id { get; set; }

            public List<int> Children { get; set; }
        }

        private static void Dfs(int n)
        {
            if (!visited[n])
            {
                visited[n] = true;

                foreach (var child in graph[n])
                {
                    Dfs(child);
                }

                Console.Write($"{n} ");
            }
        }

        public static void Main()
        {
            graph = new List<int>[]
            {
                new List<int> { 3, 6 },             //0
                new List<int> { 2, 3, 4, 5, 6 },    //1
                new List<int> { 1, 4, 5 },          //2
                new List<int> { 0, 1, 5 },          //3
                new List<int> { 1, 2, 6 },          //4
                new List<int> { 1, 2, 3 },          //5
                new List<int> { 0, 1, 4 },          //6
                new List<int> { 8 },                //7
                new List<int> { 7 }                 //8
            };

            visited = new bool[graph.Length];

            var components = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    components++;
                    Console.Write($"Connected component {components}: ");
                    Dfs(i);
                    Console.WriteLine();
                }
            }
        }
    }
}
