using System.Collections.Generic;
using System.Linq;

namespace _01.Harvesting_Fields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input = string.Empty;
            var runner = new HarvestingRunner();
            
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                PrintResults(input, runner.Harvest());
            }
        }

        private static void PrintResults(string input, Dictionary<string, string> harvest)
        {
            var list = harvest.Where(h => h.Key.Equals(input)).Select(x => x.Value).ToList();

            Console.WriteLine(string.Join(string.Empty,list));
        }
    }
}
