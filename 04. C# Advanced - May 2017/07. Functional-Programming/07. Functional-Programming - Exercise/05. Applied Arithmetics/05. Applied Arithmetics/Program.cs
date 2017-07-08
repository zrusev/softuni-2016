using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<long, long> Add = n => n + 1;
            Func<long, long> Substract = n => n - 1;
            Func<long, long> Multiply = n => n * 2;
            //Action<long> Print = n => Console.Write(n + " ");

            var numbers = Console.ReadLine()
                .Split(new[] {' ', ',', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var commmand = Console.ReadLine();

            while (!commmand.Equals("end"))
            {
                switch (commmand)
                {
                    case "add":
                        LoopList(numbers, Add);
                        break;
                    case "subtract":
                        LoopList(numbers, Substract);
                        break;
                    case "multiply":
                        LoopList(numbers, Multiply);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
                commmand = Console.ReadLine();
            }
            Console.WriteLine();
        }

        private static List<long> LoopList(List<long> numbers, Func<long, long> action)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = action(numbers[i]);
            }
            return numbers;
        }
    }
}

