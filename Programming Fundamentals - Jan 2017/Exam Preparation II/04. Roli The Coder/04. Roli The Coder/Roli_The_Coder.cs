namespace _04.Roli_The_Coder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Roli_The_Coder
    {
        public static void Main()
        {
            var dict = new SortedDictionary<int, Events>();
            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("Time for Code", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var regex = new Regex(@"\d+\s+#[\w\d]+(\s+(?:@\w+\s*)+)?");
                if (!regex.IsMatch(input))
                {
                    continue;
                }

                var tokens = input
                    .Split(new string[] { " #", " @" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Events currentEvent = new Events();
                currentEvent.ID = int.Parse(tokens.First());
                currentEvent.Name = tokens.Skip(1).First();
                currentEvent.Participants = new SortedSet<string>();

                for (int i = 2; i < tokens.Length; i++)
                {
                    currentEvent.Participants.Add(tokens[i]);
                }

                if (!dict.ContainsKey(currentEvent.ID))
                {
                    dict.Add(currentEvent.ID, currentEvent);
                }
                else if (currentEvent.Name.Equals(dict[currentEvent.ID].Name))
                {
                    dict[currentEvent.ID].Participants.UnionWith(currentEvent.Participants);
                }
            }

            var newDict = dict
                .OrderByDescending(x => x.Value.Participants.Count)
                .ThenBy(x => x.Value.Name);
                
            foreach (var key in newDict)
            {
                Console.WriteLine($"{key.Value.Name} - {key.Value.Participants.Count}");
                foreach (var item in key.Value.Participants)
                {
                    Console.WriteLine($"@{item}");
                }
            }
        }
    }
}
