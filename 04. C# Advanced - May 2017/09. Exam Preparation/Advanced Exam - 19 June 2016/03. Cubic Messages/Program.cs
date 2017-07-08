using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var patternValid = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$";

            string inputMessage;

            while ((inputMessage = Console.ReadLine()) != "Over!")
            {
                var messageLength = int.Parse(Console.ReadLine());

                var match = Regex.Match(inputMessage, patternValid);
                if (match.Success)
                {
                    var prefix = match.Groups[1].Value;
                    var message = match.Groups[2].Value;
                    var ending = string.Empty;
                    if (match.Groups[3].Value != "")
                    {
                        ending = match.Groups[3].Value;
                    }

                    if (message.Length != messageLength)
                    {
                        continue;
                    }

                    var indexes = Regex.Replace(prefix + ending, @"\D*", String.Empty);
                    var stringBuilder = new StringBuilder();
                    foreach (var index in indexes)
                    {
                        var ind = int.Parse(index.ToString());
                        if (ind >= 0 && ind < messageLength)
                        {
                            stringBuilder.Append(message[ind]);
                        }
                        else
                        {
                            stringBuilder.Append(" ");
                        }
                    }
                    Console.WriteLine($"{message} == {stringBuilder}");
                }
            }
        }
    }
}
