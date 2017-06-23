using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _14.LettersNum
{
    public class Program
    {
        public static void Main()
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVQXYZ";
            var list = new List<char>(alphabet.ToCharArray());

            var tokens = Console.ReadLine().Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Regex template = new Regex(@"\d+");
            Regex templateA = new Regex(@"^[A-Z]");
            Regex templateB = new Regex(@"[A-Z]\b");
            decimal number = 0;
            decimal sum = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                decimal tempSum = 0;
                var intA = 0;
                var intB = 0;
                char firstLetterIndex = tokens[i][0];
                char lastLetterIndex = tokens[i][tokens[i].Length - 1];
                
                Match match = template.Match(tokens[i]);
                number = int.Parse(match.Value);

                Match matchA = templateA.Match(tokens[i]);
                intA = list.IndexOf(Char.ToUpper(firstLetterIndex)) + 1;
                if (matchA.Success)
                {
                    tempSum = number / intA;
                }
                else
                {
                    tempSum = number * intA;
                }

                Match matchB = templateB.Match(tokens[i]);
                intB = list.IndexOf(Char.ToUpper(lastLetterIndex)) + 1;

                if (!matchB.Success)
                {
                    tempSum += intB;
                }
                else
                {
                    tempSum -= intB;
                }

                sum += tempSum;
            }

            Console.WriteLine($"{sum:f2}");

        }
    }
}
