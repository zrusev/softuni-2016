using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Ch
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                bool result = true;
                for (int a = 2; a <= Math.Sqrt(i); a++)
                {
                    if (i % a == 0)
                    {
                        result = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {result}");
            }


        }
    }
}
