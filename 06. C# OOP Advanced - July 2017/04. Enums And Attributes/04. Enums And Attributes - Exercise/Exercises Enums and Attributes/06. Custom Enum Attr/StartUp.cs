using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Card_Power;

namespace _06.Custom_Enum_Attr
{
    public class StartUp
    {
        public static void Main()
        {
            PrintAttribute();
        }

        public static void PrintAttribute()
        {
            var input = Console.ReadLine();
            if (input == "Rank")
            {
                PrintAttribute(typeof(Rank));

            }
            else
            {
                PrintAttribute(typeof(Suit));
            }
        }

        public static void PrintAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            Console.WriteLine(attributes[0]);
        }
    }
}
