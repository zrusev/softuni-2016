using System;


namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main()
        {

            string input = Console.ReadLine();

            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (input[i] == alphabet[j])
                    {
                        Console.WriteLine(input[i] + " -> " + j);
                        break;
                    }
                }
            }



        }
    }
}
