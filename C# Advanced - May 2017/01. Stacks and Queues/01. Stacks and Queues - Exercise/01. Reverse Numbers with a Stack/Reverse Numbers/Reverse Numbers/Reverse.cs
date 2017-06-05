using System.Linq;

namespace Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    public class Reverse
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                            .Trim()
                            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            var stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
