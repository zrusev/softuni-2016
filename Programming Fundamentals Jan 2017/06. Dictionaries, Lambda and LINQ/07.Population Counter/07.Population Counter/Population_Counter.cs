using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.PopulationCounter
{
    class PopulationCounter
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populations = new Dictionary<string, Dictionary<string, long>>();
            string line = Console.ReadLine();
            while (true)
            {
                string[] lineArr = line.Split('|');
                string city = lineArr[0];
                if (city == "report")
                {
                    break;
                }
                string country = lineArr[1];
                long people = long.Parse(lineArr[2]);
                if (!populations.ContainsKey(country))
                {
                    populations.Add(country, new Dictionary<string, long>());
                    populations[country].Add(city, people);
                }
                else
                {
                    populations[country].Add(city, people);
                }
                line = Console.ReadLine();
            }
            Dictionary<string, long> populationTotals = new Dictionary<string, long>();
            foreach (KeyValuePair<string, Dictionary<string, long>> p in populations)
            {
                populationTotals.Add(p.Key, populations[p.Key].Values.Aggregate((a, b) => b + a));
            }
            var items = from pair in populationTotals
                        orderby pair.Value descending
                        select pair;
            foreach (KeyValuePair<string, long> pair in items)
            {
                Console.WriteLine($"{pair.Key} (total population: {pair.Value})");
                var elements = from couple in populations[pair.Key]
                               orderby couple.Value descending
                               select couple;
                foreach (KeyValuePair<string, long> q in elements)
                {
                    Console.WriteLine($"=>{q.Key}: {q.Value}");
                }
            }
        }
    }
}