namespace _04.Cubic_Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text;

    public class Cubic_Messages
    {
        public static void Main()
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Over!")
                {
                    break;
                }

                var count = int.Parse(Console.ReadLine());

                var regex = new Regex($@"(^\d+)([A-Za-z]{{{count}}})([^A-Za-z]*$)");
                var match = regex.Match(line);

                if (match.Success)
                {
                    var left = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var right = match.Groups[3].Value;

                    var indexes = string.Concat(left, right)
                        .Where(char.IsDigit)
                        .Select(s => s - '0');

                    var result = new StringBuilder();
                    foreach (var index in indexes)
                    {
                        if (index < 0 || index >= message.Length)
                        {
                            result.Append(' ');
                        }
                        else
                        {
                            result.Append(message[index]);
                        }
                                
                     }

                    Console.WriteLine($"{message} == {result}");
                }

            }
        }
    }
}
