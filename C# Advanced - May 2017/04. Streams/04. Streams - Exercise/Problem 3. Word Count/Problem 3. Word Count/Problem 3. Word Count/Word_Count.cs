using System.Linq;
using System.Linq.Expressions;

namespace Problem_3.Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Word_Count
    {
        public static void Main()
        {
            var dict = new Dictionary<string, int>();
            
            using (StreamReader wordsReader = new StreamReader(@"..\..\words.txt"))
            {
                var line = wordsReader.ReadLine();
                while (line != null)
                {
                    dict.Add(line.ToLower(), 0);
                    line = wordsReader.ReadLine();
                }
            }

            StreamReader textReader = new StreamReader(@"..\..\text.txt");

            string[] text;
            using (textReader)
            {
                text = textReader.ReadToEnd().ToLower().Split(new []{' ', ',', '.', '!', '?', '-', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < dict.Count; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j].Equals(dict.ElementAt(i).Key))
                    {
                        dict[dict.ElementAt(i).Key] = dict[dict.ElementAt(i).Key] + 1;
                    }

                }
            }
            var newDict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            StreamWriter resultWriter = new StreamWriter(@"..\..\result.txt");

            using (resultWriter)
            { 
              foreach (var item in newDict)
              {
                resultWriter.AutoFlush = true;
                resultWriter.WriteLine($"{item.Key} - {item.Value}");
              }
            }
        }
    }
}
