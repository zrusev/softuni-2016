using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Cubic_Assault
{
   public class Program
   {
        public static int ConverThreshold = 1_000_000;
        public static void Main()
        {
            var mereorNames = new List<string>(){"Green", "Red", "Black"};
            var regions = new Dictionary<string, Dictionary<string, long>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Count em all")
            {
                var regionTokens = inputLine.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var regionName = regionTokens[0];
                var meteorType = regionTokens[1];
                var meteorCount = int.Parse(regionTokens[2]);

                if (!regions.ContainsKey(regionName))
                {
                    regions[regionName] = new Dictionary<string, long>(){{"Green", 0}, {"Red", 0}, {"Black", 0}};
                }

                regions[regionName][meteorType] += meteorCount;

                for (int i = 0; i < mereorNames.Count - 1; i++)
                {
                    var nextTypeCount = regions[regionName][mereorNames[i]] / ConverThreshold;

                    if (nextTypeCount > 0)
                    {
                        regions[regionName][mereorNames[i + 1]] += nextTypeCount;
                        regions[regionName][mereorNames[i]] %= ConverThreshold;
                    }
                }                
            }

            var orderedRegions = regions.OrderByDescending(r => r.Value["Black"]).ThenBy(r => r.Key.Length).ThenBy(r => r.Key).ToDictionary(r => r.Key, r => r.Value);

            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key);
                foreach (var mtType in region.Value.OrderByDescending(m => m.Value).ThenBy(m => m.Key))
                {
                    Console.WriteLine($"-> {mtType.Key} : {mtType.Value}");
                }
            }
        }
    }
}
