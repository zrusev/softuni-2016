using System.Linq;

namespace _02.Basic_Stack
{
    using System;
    using System.Collections.Generic;
    public class Basic_Stack
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Trim()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = input[0];
            var s = input[1];
            var x = input[2];

            var stack = new Stack<int>();

            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < n; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.ToArray().Min());
            }

        }
    }
}
