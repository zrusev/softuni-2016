namespace _07.Multiply_big_number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Multiply_big_number
    {
        static void Main()
        {

            var input = Console.ReadLine();
            var indeX = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] - '0') == 0)
                {
                    indeX = i + 1;
                }
                else
                {
                    break;
                }
            }

            var number = input.Substring(indeX, input.Length - indeX).Trim().ToCharArray();
            var multiplier = int.Parse(Console.ReadLine());
            var list = new List<int>();

            var temp = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                var result = (number[i] - '0') * multiplier;
                list.Add((result + temp) % 10);
                temp = (result + temp) / 10;
            }

            if (temp > 0)
            {
                list.Add(temp);
            }
            list.Reverse();
            Console.WriteLine(string.Join(string.Empty, list));

        }
    }
}
