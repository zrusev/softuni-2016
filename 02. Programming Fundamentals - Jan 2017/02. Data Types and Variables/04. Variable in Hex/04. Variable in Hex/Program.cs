using System;


namespace _04.Variable_in_Hex
{
    class Program
    {
        static void Main(string[] args)
        {

            string num1 = Console.ReadLine();
            //string num2 = "0x37";
            //string num3 = "0x10";

            Console.WriteLine(Convert.ToInt32(num1, 16));
            //Console.WriteLine(Convert.ToInt32(num2, 16));
            //Console.WriteLine(Convert.ToInt32(num3, 16));


        }

    }

}



