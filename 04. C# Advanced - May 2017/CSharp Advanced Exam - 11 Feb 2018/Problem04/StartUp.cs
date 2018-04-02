using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Problem04
{
    using System;
    public class StartUp
    {
        public static void Main()
        {

            var library = new Dictionary<string, Dictionary<string, string>>();
            var targetIndex = int.Parse(Console.ReadLine());

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var line = input.Split(new []{'=', ':', ';'}).ToArray();
                var personName = line[0];
                var tempDict = new Dictionary<string, string>();

                for (int i = 1; i < line.Length; i += 2)
                {
                    var skillName = string.Empty;
                    var skillValue = string.Empty;

                    skillName = line[i];
                    skillValue = line[i + 1];
                    
                    if (!tempDict.ContainsKey(skillName))
                    {
                        tempDict.Add(skillName, skillValue);
                    }
                    else
                    {
                        tempDict[skillName] = skillValue;
                    }
                }

                if (!library.ContainsKey(personName))
                {
                    library.Add(personName, tempDict);
                }
                else
                {
                    foreach (var tempDictKey in tempDict.Keys)
                    {
                        if (library[personName].ContainsKey(tempDictKey))
                        {
                            library[personName][tempDictKey] = tempDict[tempDictKey];
                        }
                        else
                        {
                            library[personName].Add(tempDictKey, tempDict[tempDictKey]);
                        }
                    }
                }
            }
            var whoToKill = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var personToKill = whoToKill[1];
            var personIndex = 0;

            Console.WriteLine($"Info on {personToKill}:");
            foreach (var kvp in library[personToKill].OrderBy(k => k.Key))
            {
                personIndex += (kvp.Key.Length + kvp.Value.Length);
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {personIndex}");
            if (personIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - personIndex} more info.");
            }
        }
    }
}
