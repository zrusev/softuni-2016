namespace Searching
{
    using System;

    public class StartUp
    {
        static int[] collection = new int[10] { 2, 1, 5, 11, 4, 6, 20, 7, 3, 10 };

        public static void Main()
        {
            Console.WriteLine(LinearSearch(5));

            Console.WriteLine(BinarySearch(5));

            Console.WriteLine(FibonacciSearch(10));
        }

        private static int FibonacciSearch(int find)
        {
            int p = 0;
            int q = 1;

            for (int i = 0; i < find; i++)
            {
                int temp = p;
                p = q;
                q = temp + q;
            }

            return p;
        }

        private static int BinarySearch(int find)
        {
            //return Array.BinarySearch(collection, find);

            int min = 0;
            int N = collection.Length;
            int max = N - 1;

            do
            {
                int mid = (min + max) / 2;

                if (find > collection[mid])
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
                if (collection[mid] == find)
                {
                    return mid;
                }
                if (min > max)
                {
                    break;
                }
            } while (min <= max);

            return -1;
        }

        private static int LinearSearch(int find)
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);

            int index = Array.IndexOf(numbers, find);

            return index;
        }
    }
}
