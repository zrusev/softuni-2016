namespace _09.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;
    public class Stack_Fibonacci
    {
        public static void Main()
        {
            Console.WriteLine(Fibonacci(long.Parse(Console.ReadLine())));
        }

        public static long Fibonacci(long n)
        {
            var stack = new Stack<long>();
            stack.Push(0);
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                long temp = stack.Peek();
                stack.Push(b);
                b = temp + b;
            }
            return stack.Pop();
        }
    }
}
