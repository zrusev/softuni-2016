using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Ashes_of_Roses
{
    class Program
    {
        static void Main(string[] args)
        {
            var regions = new Dictionary<string, SortedDictionary<string, long>>();
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "Icarus, Ignite!")
            {                
                if (Regex.IsMatch(inputLine, @"^Grow\s<[A-Z][a-z]+>\s<[a-zA-Z0-9]+>\s[\d]+$"))
                {
                    var tokens = inputLine.Split(new[] { '>', '<', ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    var regionName = tokens[1];
                    var colorName = tokens[2];
                    var roseAmount = tokens[3];

                    if (!regions.ContainsKey(regionName))
                    {                    
                       regions.Add(regionName, new SortedDictionary<string, long>());
                       
                       if (!regions[regionName].ContainsKey(colorName))
                       {
                            regions[regionName].Add(colorName, long.Parse(roseAmount));
                       }
                       else
                       {
                            regions[regionName][colorName] += long.Parse(roseAmount);
                       }
                        
                    }

                    else
                    {
                       if (!regions[regionName].ContainsKey(colorName))
                       {
                            regions[regionName].Add(colorName, long.Parse(roseAmount));
                       }
                       else
                       {
                            regions[regionName][colorName] += long.Parse(roseAmount);
                       }
                    }
                }
            }

            var ordered = regions.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key);

            foreach (var region in ordered)
            {
                Console.WriteLine(region.Key);

                var reorder = region.Value.OrderBy(x => x.Value).ThenBy(x => x.Key);

                foreach (var color in reorder)
                {
                    Console.WriteLine($"*--{color.Key} | {color.Value}");
                }
            }

        }
    }
}
