namespace _08.Logs_Aggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Logs_Aggregator
    {
        static void Main()
        {
            var dict = new SortedDictionary<string, SortedDictionary<string, int>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                var name = input[1];
                var ip = input[0];
                var session = int.Parse(input[2]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new SortedDictionary<string, int>();
                    dict[name].Add(ip, session);
                }
                else
                {
                    if (!dict[name].ContainsKey(ip))
                    {
                        dict[name][ip] = session;
                    }
                    else
                    {
                        dict[name][ip] += session;
                    }
                    
                }
            }

            foreach (var item in dict)
            {
                var sum = dict[item.Key].Values.Aggregate((a, b) => b + a);
                var ips = item.Value.Select(x => x.Key).ToList();
                
                var ipsCollection = string.Join(", ", ips.ToArray());
                Console.WriteLine($"{item.Key}: {sum} [{ipsCollection}]");
            }                           
        }
    }
}
