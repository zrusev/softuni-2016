using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int a = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int leftSum = 0, rightSum = 0;
                for (int j = 0; j <= i; j++)
                { leftSum += array[j]; }
                for (int k = array.Length - 1; k >= i; k--)
                { rightSum += array[k]; }
                if (leftSum == rightSum)
                { Console.WriteLine(i); a = 1; }
            }
            if (a == 0)
            { Console.WriteLine("no"); }
        }
    }
}

