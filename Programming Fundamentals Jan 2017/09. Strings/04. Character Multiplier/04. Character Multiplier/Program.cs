namespace _04.Character_Multiplier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            char[] arr1 = input[0].ToCharArray();
            char[] arr2 = input[1].ToCharArray();
            decimal result = 0;

            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                    decimal temp = arr1[i] * arr2[i];
                    result += temp;
            }

            if (arr1.Length > arr2.Length)
            {
                for (int i = arr1.Length - 1; i > arr2.Length - 1; i--)
                {
                    result += arr1[i];
                }
            }
            else
            {
                for (int i = arr2.Length - 1; i > arr1.Length - 1; i--)
                {
                    result += arr2[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}
