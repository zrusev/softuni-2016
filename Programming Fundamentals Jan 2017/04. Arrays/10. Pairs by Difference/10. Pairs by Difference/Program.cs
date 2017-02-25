using System;
using System.Linq;


namespace _10.Pairs_by_Difference
{
    class Program
    {
        static void Main()
        {

            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int step = int.Parse(Console.ReadLine());

            var counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) == step)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}