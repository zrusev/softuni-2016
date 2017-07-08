using System;


namespace _02.Max_Method
{
    class Program
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMax(GetMax(num1, num2), num3));

        }

        static int GetMax(int a, int b)
        {
            var result = Math.Max(a, b);
            return result;
        }
    }
}