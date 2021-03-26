namespace Combinations
{
    using System;

    public class Program
    {
        private static int[] arr;
        private static int n = 5;
        private static int k = 3;

        private static void Print()
            => Console.WriteLine(string.Join(" ", arr));

        private static void Combine(int index, int start)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    Combine(index + 1, i + 1);
                }
            }
        }

        public static void Main()
        {
            arr = new int[k];
            Combine(0, 0);
        }
    }
}