namespace _10.Сръбско_Unleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Сръбско_Unleashed
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> singers = new Dictionary<string, Dictionary<string, long>>();

            string[] line;
            while (true)
            {
                line = Console.ReadLine().Split(' ');
                if (line[0] == "End")
                    break;

                bool getLoc = false;
                string singer = "";
                string location = "";
                byte ticketsPrice = 0;
                int ticketsCount = 0;

                if (byte.TryParse(line[line.Length - 2], out ticketsPrice) && int.TryParse(line[line.Length - 1], out ticketsCount))
                {
                    for (int i = 0; i < line.Length - 2; i++)
                    {
                        if (line[i][0] == '@' || getLoc)
                        {
                            location += line[i] + " ";
                            getLoc = true;
                        }
                        else
                        {
                            singer += line[i] + " ";
                        }
                    }

                    if (singer.Length > 0 && location.Length > 0)
                    {
                        singer = singer.Trim();
                        location = location.Trim().Substring(1);

                        if (!singers.ContainsKey(location))
                        {
                            singers.Add(location, new Dictionary<string, long>());
                        }

                        long oldPrice = 0;
                        singers[location].TryGetValue(singer, out oldPrice);
                        singers[location][singer] = oldPrice + ticketsCount * ticketsPrice;
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, long>> entry in singers)
            {
                Console.WriteLine(entry.Key);
                var singerPrice = entry.Value.OrderByDescending(pair => pair.Value);
                foreach (KeyValuePair<string, long> entry2 in singerPrice)
                {
                    Console.WriteLine("#  {0} -> {1}", entry2.Key, entry2.Value);
                }
            }
        }
    }
}