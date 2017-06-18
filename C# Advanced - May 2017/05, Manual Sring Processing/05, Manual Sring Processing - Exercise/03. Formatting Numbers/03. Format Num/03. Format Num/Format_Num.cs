using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Format_Num
{
    public class Format_Num
    {
        public static void Main()
        {
            string[] inputParam = Console.ReadLine().Split(new []{' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(inputParam[0]);
            double b = double.Parse(inputParam[1]);
            double c = double.Parse(inputParam[2]);

            string hexadecimalNumber = a.ToString("X");
            string result = "|" + hexadecimalNumber.PadRight(10) + "|";
            string binaryNumber = Convert.ToString(a, 2);
            result = result + binaryNumber.PadLeft(10, '0').Substring(0, 10) + "|";
            result = result + b.ToString("0.00").PadLeft(10) + "|";
            result = result + c.ToString("0.000").PadRight(10) + "|";

            Console.WriteLine(result);
        }
    }
}
