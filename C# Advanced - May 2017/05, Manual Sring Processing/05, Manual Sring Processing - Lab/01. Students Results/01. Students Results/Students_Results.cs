using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students_Results
{
    public class Students_Results
    {
        public static void Main()
        {
            var students = int.Parse(Console.ReadLine());

            Console.WriteLine("{0, -10}|{1, 7}|{2, 7}|{3, 7}|{4, 7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");
            for (int i = 0; i < students; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' ', '-', ','}, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var firstNum = double.Parse(tokens[1]);
                var secondtNum = double.Parse(tokens[2]);
                var thirdtNum = double.Parse(tokens[3]);
                var avr = (firstNum + secondtNum + thirdtNum) / 3;

                Console.WriteLine("{0, -10}|{1, 7:F2}|{2, 7:F2}|{3, 7:F2}|{4, 7:F4}|", name, firstNum, secondtNum, thirdtNum, avr);
            }
        }
    }
}
