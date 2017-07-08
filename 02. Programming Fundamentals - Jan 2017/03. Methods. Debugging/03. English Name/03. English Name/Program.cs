using System;


namespace _03.English_Name
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var txt = input[input.Length - 1];

            PrintLastDigit(txt);


        }

        static void PrintLastDigit(char txt)
        {

            switch ((int)txt)
            {
                case 48: Console.WriteLine("zero"); break;
                case 49: Console.WriteLine("one"); break;
                case 50: Console.WriteLine("two"); break;
                case 51: Console.WriteLine("three"); break;
                case 52: Console.WriteLine("four"); break;
                case 53: Console.WriteLine("five"); break;
                case 54: Console.WriteLine("six"); break;
                case 55: Console.WriteLine("seven"); break;
                case 56: Console.WriteLine("eight"); break;
                case 57: Console.WriteLine("nine"); break;
            }
        }
    }
}
