using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> IsOdd = n => n % 2 == 0;

            var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var start = input[0];
            var end = input[1];
            var command = Console.ReadLine();

            switch (command)
            {
                case "odd":
                    Console.WriteLine(string.Join(" ", ExtendInput(start, end, IsOdd, command)));
                    break;
                case "even":
                    Console.WriteLine(string.Join(" ", ExtendInput(start, end, IsOdd, command)));
                    break;
            }
                           
        }

        private static List<int> ExtendInput(int x, int y, Predicate<int> check, string command)
        {
            var listO = new List<int>();
            var listE = new List<int>();

            for (int i = x; i <= y; i++)
            {
                switch (check(i))
                {
                    case true:
                        listE.Add(i);
                        break;
                    case false:
                        listO.Add(i);
                        break;
                }                
            }
            if (command.Equals("odd"))
            {
                return listO;
            }
            else
            {
                return listE;
            }
        }
    }
}
