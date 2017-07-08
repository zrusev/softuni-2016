using System.Collections.Generic;

namespace Problem_1.Odd_Lines
{
    using System;
    using System.IO;
    public class Odd_Lines
    {
        public static void Main()
        {
            using (StreamReader stream = new StreamReader(@"..\..\OddNumbers.txt"))
            {
                var line = stream.ReadLine();
                var i = 0;

                while (line != null)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }
                    i++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
