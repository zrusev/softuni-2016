﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Custom_Attribute
{
    using System;

    public class Program
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
                PrintAttribute(typeof(CardRanks));

            }
            else
            {
                PrintAttribute(typeof(CardSuits));
            }
        }

        public static void PrintAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            Console.WriteLine(attributes[0]);
        }
    }
}
