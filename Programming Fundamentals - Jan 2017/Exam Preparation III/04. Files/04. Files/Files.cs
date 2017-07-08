namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Files
    {
        static void Main()
        {
            var filesByRoot = new Dictionary<string, Dictionary<string, long>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] routeParames = Console.ReadLine().Split('\\');

                string root = routeParames[0];
                string[] fileWithSize = routeParames[routeParames.Length - 1].Split(';');

                string fileNameWithExtension = fileWithSize[0];
                long fileSize = long.Parse(fileWithSize[1]);

                if (!filesByRoot.ContainsKey(root))
                {
                    filesByRoot.Add(root, new Dictionary<string, long>());

                }
                if (!filesByRoot[root].ContainsKey(fileNameWithExtension))
                {
                    filesByRoot[root].Add(fileNameWithExtension, fileSize);
                }
                else
                {
                    filesByRoot[root][fileNameWithExtension] = fileSize;
                }
            }

            string[] queryParams = Console.ReadLine().Split(new[] { ' '});

            string queryExtension = queryParams[0];
            string queryRoot = queryParams[2];

            if (filesByRoot.ContainsKey(queryRoot))
            {
                Dictionary<string, long> foundFiles = filesByRoot[queryRoot];

                foreach (var file in foundFiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (file.Key.EndsWith(queryExtension))
                    {
                        Console.WriteLine("{0} - {1} KB", file.Key, file.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
