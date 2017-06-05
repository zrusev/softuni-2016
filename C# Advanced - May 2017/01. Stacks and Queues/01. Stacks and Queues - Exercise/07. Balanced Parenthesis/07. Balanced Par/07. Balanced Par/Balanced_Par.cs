using System.Linq;

namespace _07.Balanced_Par
{
    using System;
    using System.Collections.Generic;
    public class Balanced_Par
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToArray();
            var stack = new Stack<int>();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 123 || input[i] == 91 || input[i] == 40 || input[i] == 32)
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Pop() - input[i] > 2)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
