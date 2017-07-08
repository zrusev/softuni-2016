namespace Problem_2.Line_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class Line_Numbers
    {
        public static void Main()
        {
            var list = new List<string>();
            using (var reader = new StreamReader(@"..\..\Numbers.txt"))
            {
                var line = reader.ReadLine();
                var i = 1;

                while (line != null)
                {
                    list.Add(i + ". " + line);
                    line = reader.ReadLine();
                    i++;
                }
            }
            using (var writer = new StreamWriter(@"..\..\NumbersResult.txt", true))
            {
                writer.AutoFlush = true;
                writer.WriteLine(string.Join("" + Environment.NewLine, list));
            }
        }
    }
}
