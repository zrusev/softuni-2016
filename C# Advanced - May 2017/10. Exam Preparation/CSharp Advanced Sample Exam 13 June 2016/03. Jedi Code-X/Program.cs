using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                text.Append(input);
            }

            string namePattern = Console.ReadLine();
            string messagePattern = Console.ReadLine();
            int[] messageIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Regex rgxName =
                new Regex(Regex.Escape(namePattern) + @"([A-Za-z]{" + namePattern.Length + @"})(?![A-Za-z])");
            Regex rgxMessage = new Regex(Regex.Escape(messagePattern) + @"([A-Za-z0-9]{" + messagePattern.Length +
                                         @"})(?![a-zA-Z0-9])");

            List<string> jedisNames = new List<string>();
            List<string> jedisMessages = new List<string>();

            MatchCollection jedisMatches = rgxName.Matches(text.ToString());
            MatchCollection messageMatches = rgxMessage.Matches(text.ToString());

            foreach (Match item in jedisMatches)
                jedisNames.Add(item.Groups[1].Value);

            foreach (Match item in messageMatches)
                jedisMessages.Add(item.Groups[1].Value);

            int currentJediIndex = 0;
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < messageIndexes.Length; i++)
            {
                if (messageIndexes[i] - 1 < jedisMessages.Count)
                {
                    output.AppendLine($"{jedisNames[currentJediIndex]} - {jedisMessages[messageIndexes[i] - 1]}");
                    currentJediIndex++;
                }

                if (currentJediIndex >= jedisNames.Count)
                    break;
            }

            Console.WriteLine(output.ToString());
        }
    }
}