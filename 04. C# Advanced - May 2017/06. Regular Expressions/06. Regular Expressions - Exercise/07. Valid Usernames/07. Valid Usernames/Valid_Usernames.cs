using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.Valid_Usernames
{
    public class Valid_Usernames
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            //var regex = new Regex(@"(?<=[\\\/(\)\s])[A-Za-z]\w{2,25}(?<![\\\/(\)\s])");
            var dict = new Dictionary<string, int>();
            Match match = Regex.Match(" " + line, @"(?<=[\\\/(\)\s])[A-Za-z]\w{2,25}(?<![\\\/(\)\s])");


            //foreach (Match match in regex.Matches(" " + line))
            //{
            //    dict.Add(match.Length, match.Value);
            //}
            var temp = 0;

            while (match.Success)
            {
                var now = match.Value;
                var next = match.NextMatch().Value;

                if (match.Length + match.NextMatch().Length > temp)
                {
                    dict.Clear();
                    dict.Add(match.Value, match.Length);
                    if (!dict.ContainsKey(match.NextMatch().Value))
                    {
                        dict.Add(match.NextMatch().Value, match.NextMatch().Length);
                    }                    
                }

                temp = match.Length + match.NextMatch().Length;
                match = match.NextMatch();
            }

            var lastStr = string.Empty;
            foreach (var i in dict)
            {
                lastStr = i.Key;
                Console.WriteLine(lastStr);
            }

            if (dict.Count == 1)
            {
                Console.WriteLine(lastStr);
            }

        }
    }
}
