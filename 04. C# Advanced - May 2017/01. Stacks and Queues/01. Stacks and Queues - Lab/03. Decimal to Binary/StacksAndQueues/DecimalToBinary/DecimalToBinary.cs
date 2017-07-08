namespace DecimalToBinary
{
    using System;
    using System.Collections.Generic;

    public static class DecimalToBinary
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input != 0)
                {
                    stack.Push(input % 2);
                    input /= 2;
                }
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
