namespace _06.Generic_Count_Method_String
{
    using System;
    using _04.Generic_Swap_Method_String;
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> list = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.AddValue(input);
            }

            string itemToCompare = Console.ReadLine();

            int count = list.Compare(itemToCompare);

            Console.WriteLine(count);
        }
    }
}
