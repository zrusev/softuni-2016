using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Legendary_F
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            var input = string.Empty;
            dict.Add("shards", 0);
            dict.Add("motes", 0);
            dict.Add("fragments", 0);

            while (true)
            {
                input = Console.ReadLine();
                var list = input
                    .ToLower()
                    .Split()
                    .ToList();

                for (int i = 0; i < list.Count; i = i + 2)
                {
                    if (!dict.ContainsKey(list[i + 1]))
                    {
                        dict.Add(list[i + 1], int.Parse(list[i]));
                    }
                    else
                    {
                        dict[list[i + 1]] += int.Parse(list[i]);
                    }

                    if (dict[list[i + 1]] >= 250)
                    {
                        if ((list[i + 1].Equals("shards") || list[i + 1].Equals("fragments") || list[i + 1].Equals("motes")))
                        {
                            switch (list[i + 1])
                            {
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }
                            dict[list[i + 1]] -= 250;
                            goto EndWhile;
                        }
                    }
                }
            }
            EndWhile:
            var sdict = dict
                .Take(3)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key);
            foreach (var item in sdict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            var sortedDict = dict
                .Skip(3)
                .OrderBy(x => x.Key);
            foreach (var item in sortedDict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
