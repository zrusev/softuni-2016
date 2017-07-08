namespace _04.Winning_Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var tickets = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                var left = new string(ticket.Take(10).ToArray());
                var right = new string(ticket.Skip(10).ToArray());

                var winningSymbols = new string[] { "@" , "#", "\\$", @"\\^" };
                var winningTicket = false;

                foreach (var winnnigSymbol in winningSymbols)
                {
                    var regex = new Regex($"{winnnigSymbol}{{6,}}");
                    var leftMatch = regex.Match(left);
                    if (leftMatch.Success)
                    {
                        var rightMatch = regex.Match(right);
                        if (rightMatch.Success)
                        {
                            winningTicket = true;

                            var leftSymbolsLength = leftMatch.Value.Length;
                            var rightSymbolsLength = rightMatch.Value.Length;
                            var jackpot = leftSymbolsLength == 10 && rightSymbolsLength == 10
                            ? " Jackpot!"
                            : string.Empty;

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftSymbolsLength, rightSymbolsLength)}{winnnigSymbol.Trim('\\')}{jackpot}");

                            break;
                        }
                    }
                }

                if (!winningTicket)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }


            }
        }
    }
}
