using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] values = new int[numbers.Length];

            List<int> numbersSeen = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersSeen.Contains(numbers[i]))
                {
                    values[Array.IndexOf(numbers, numbers[i])]++;
                }
                else
                {
                    values[Array.IndexOf(numbers, numbers[i])]++;
                    numbersSeen.Add(numbers[i]);
                }
            }
            int max = numbers[Array.IndexOf(values, values.Max())];

            Console.WriteLine(max);
        }
    }
}
