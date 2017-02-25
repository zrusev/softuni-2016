using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Print_Part_Of
{
    class Program
    {
        static void Main(string[] args)
        {

            byte first = byte.Parse(Console.ReadLine());

            byte second = byte.Parse(Console.ReadLine());

            for (byte i = first; i <= second; i++)
            {

                Console.Write((char)i + " ");
            }
        }
    }
}
