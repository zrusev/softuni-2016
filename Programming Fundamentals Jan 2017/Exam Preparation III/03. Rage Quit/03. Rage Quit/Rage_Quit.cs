namespace _03.Rage_Quit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Rage_Quit
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var regex = new Regex(@"(?<pairs>[^\d]+)(?<repeatCount>\d*)");
            var matches = regex.Matches(inputLine);
            var listOfSymbols = new List<string>();
            var uniqueSymbos = new HashSet<char>();

            foreach (Match match in matches)
            {
                listOfSymbols.Add(Repeat(match.Groups[1].Value.ToUpper(), int.Parse(match.Groups[2].Value)));
                foreach (var symbol in listOfSymbols[listOfSymbols.Count - 1])
                {
                    uniqueSymbos.Add(symbol);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbos.Count}");
            Console.WriteLine(string.Join("", listOfSymbols));

        }

        public static string Repeat(string value, int count)
        {
            return new StringBuilder(value.Length * count).Insert(0, value, count).ToString();
        }
    }
}
