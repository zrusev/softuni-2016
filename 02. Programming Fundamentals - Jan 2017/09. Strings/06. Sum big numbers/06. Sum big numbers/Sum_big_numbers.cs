namespace _06.Sum_big_numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Sum_big_numbers
    {
        static void Main()
        {

            var firstNumber = Console.ReadLine().ToCharArray().Reverse().ToArray();
            var secondNumber = Console.ReadLine().ToCharArray().Reverse().ToArray();
            var list = new List<int>();

            var temp = 0;
            for (int i = 0; i < Math.Min(firstNumber.Length, secondNumber.Length); i++)
            {
                var sum = (firstNumber[i] - '0') + (secondNumber[i] - '0') + temp;
                if (sum <= 9)
                {
                    list.Add(sum);
                    temp = 0;
                }
                else
                {
                    list.Add(sum % 10);
                    temp = sum / 10;
                }
            }

            if (firstNumber.Length > secondNumber.Length)
            {
                for (int i = secondNumber.Length; i < firstNumber.Length; i++)
                {
                    var sum = (firstNumber[i] - '0') + temp;
                    if (sum <= 9)
                    {
                        list.Add(sum);
                        temp = 0;
                    }
                    else
                    {
                        list.Add(sum % 10);
                        temp = sum / 10;
                    }
                }
            }
            else if(firstNumber.Length < secondNumber.Length)
            {
                for (int i = firstNumber.Length; i < secondNumber.Length; i++)
                {
                    var sum = (secondNumber[i] - '0') + temp;
                    if (sum <= 9)
                    {
                        list.Add(sum);
                        temp = 0;
                    }
                    else
                    {
                        list.Add(sum % 10);
                        temp = sum / 10;
                    }
                }

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
