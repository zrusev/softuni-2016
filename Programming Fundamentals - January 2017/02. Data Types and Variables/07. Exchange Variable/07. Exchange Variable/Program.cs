using System;


namespace _07.Exchange_Variable
{
    class Program
    {
        static void Main(string[] args)
        {

            byte n = 5;
            byte m = 10;

            Console.WriteLine($"Before:\na = {n}\nb = {m}");

            byte temp = m;
            m = n;
            n = temp;
            Console.WriteLine($"After:\na = {n}\nb = {m}");

        }
    }
}
