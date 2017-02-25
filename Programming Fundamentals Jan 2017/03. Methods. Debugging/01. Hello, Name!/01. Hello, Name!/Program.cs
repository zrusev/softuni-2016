using System;


namespace _01.Hello__Name_
{
    class Program
    {
        static void Main()
        {

            string input = Console.ReadLine();
            Name(input);
        }

        static void Name(string input)
        {
            Console.WriteLine($"Hello, {input}!");
        }
    }
}

