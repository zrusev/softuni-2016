using System;


namespace _05.Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {

            string num1 = Console.ReadLine();

            if (Convert.ToBoolean(num1))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

    }

}
