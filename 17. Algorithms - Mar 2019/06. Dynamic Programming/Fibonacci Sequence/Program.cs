namespace Fibonacci_Sequence
{
    using System;

    public class Program
    {
        private static int[] numbers;

        private static int Fib(int n)
        {
            if(numbers[n] != 0)
            {
                return numbers[n];
            }

            if(n == 1 || n == 2)
            {
                return 1;
            }

            var result = Fib(n - 1) + Fib(n - 2);

            numbers[n] = result;

            return result;
        }

        public static void Main()
        {
            int n = 5;
            numbers = new int[n + 1];
            Console.WriteLine(Fib(5));
        }
    }
}