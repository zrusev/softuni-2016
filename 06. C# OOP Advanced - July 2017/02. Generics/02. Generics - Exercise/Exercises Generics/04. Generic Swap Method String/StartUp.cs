using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Generic_Swap_Method_String
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> list = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.AddValue(input);
            }

            int[] reverseNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            list.Swap(reverseNumbers[0], reverseNumbers[1]);

            Console.WriteLine(list.ToString());
        }
    }
}
