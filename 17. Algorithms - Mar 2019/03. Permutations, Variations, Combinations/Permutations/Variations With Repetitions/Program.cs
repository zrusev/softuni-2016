namespace Variations_With_Repetitions
{
    using System;

    public class Program
    {
        private static int[] arr;
        private static int n = 5;
        private static int k = 3;

        private static void Print()
            => Console.WriteLine(string.Join(" ", arr));
        
        private static void Variate()
        {
            while (true)
            {
                Print();

                int index = k - 1;

                while (index >= 0 && arr[index] == n - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                arr[index]++;

                for (int i = index + 1; i < k; i++)
                {
                    arr[i] = 0;
                }
            }
        }

        public static void Main()
        {
            arr = new int[k];
            Variate();
        }
    }
}
