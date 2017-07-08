namespace _04.Sum_Reversed_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Sum_Reversed_Numbers
    {
        static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split();

            int sum = 0;

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                string currentNumber = inputNumbers[i];
                List<char> reversedNumber = currentNumber.Reverse().ToList();

                string reversedNumberSring = string.Join("", reversedNumber);
                int resultNumber = int.Parse(reversedNumberSring);
                sum += resultNumber;
            }
            Console.WriteLine(sum);
        }
    }
}
