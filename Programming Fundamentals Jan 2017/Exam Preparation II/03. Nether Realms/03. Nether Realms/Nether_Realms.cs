namespace _03.Nether_Realms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Nether_Realms
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x)
                .ToArray();
            var health = 0;
            double damage = default(double);

            foreach (var line in input)
            {

                var pattern = @"[^0-9+\-*\/\.]";
                var regex = new Regex(pattern);
                var matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    health += char.Parse(match.Value);
                }

                pattern = @"[+-]?\d+(?:\.?\d+)?";
                regex = new Regex(pattern);
                matches = regex.Matches(line);
 

                foreach (Match match in matches)
                {
                    damage += double.Parse(match.Value);
                }

                pattern = @"[*\/]";
                regex = new Regex(pattern);
                matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    switch (match.Value)
                    {
                        case "*":
                            damage *= 2;
                            break;
                        case "/":
                            damage /= 2;
                            break;
                    }
                }
                
                Console.WriteLine($"{line} - {health} health, {damage:F2} damage");

                health = 0;
                damage = 0;
            }
        }
    }
}
