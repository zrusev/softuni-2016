namespace _01.Unique_Usern
{
    using System;
    using System.Collections.Generic;
    public class Unique_Usern
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < input; i++)
            {
                var name = Console.ReadLine();

                if (!set.Contains(name))
                {
                    set.Add(name);
                }
            }

            foreach (var s in set)
            {
                Console.WriteLine(s);
            }
        }
    }
}
