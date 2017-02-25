using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Different_Integ
{
    class Program
    {
        static void Main(string[] args)
        {
            string m = Console.ReadLine();
            try
            {
                long n = long.Parse(m);
                Console.WriteLine($"{n} can fit in:");

                var salmons = new List<string>();
                salmons.Add("sbyte");
                salmons.Add("byte");
                salmons.Add("short");
                salmons.Add("ushort");
                salmons.Add("int");
                salmons.Add("uint");
                salmons.Add("long");

                foreach (var salmon in salmons)
                {
                    long minimum = 0;
                    long maximum = 0;

                    switch (salmon)
                    {
                        case "sbyte":
                            minimum = sbyte.MinValue;
                            maximum = sbyte.MaxValue;
                            break;
                        case "byte":
                            minimum = byte.MinValue;
                            maximum = byte.MaxValue;
                            break;
                        case "short":
                            minimum = short.MinValue;
                            maximum = short.MaxValue;
                            break;
                        case "ushort":
                            minimum = ushort.MinValue;
                            maximum = ushort.MaxValue;
                            break;
                        case "int":
                            minimum = int.MinValue;
                            maximum = int.MaxValue;
                            break;
                        case "uint":
                            minimum = uint.MinValue;
                            maximum = uint.MaxValue;
                            break;
                        case "long":
                            minimum = long.MinValue;
                            maximum = long.MaxValue;
                            break;
                    }
                    if (n >= minimum && n <= maximum)
                    {
                        Console.WriteLine($"* {salmon}");
                    }

                }
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{m} can't fit in any type");
            }

        }

    }
}


