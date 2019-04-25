namespace Exercise
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
        public static List<int> result = new List<int>();

        public static void Main()
        {
            int arrLength = arr.Length;
            Print(arrLength);
        }

        private static void Print(int l)
        {
            if (l == 0)
            {
                Console.Write(string.Join(' ', result.ToArray()));
                return;
            }
            else
            {
                result.Add(l);
                Print(l - 1);
            }
        }
    }
}
