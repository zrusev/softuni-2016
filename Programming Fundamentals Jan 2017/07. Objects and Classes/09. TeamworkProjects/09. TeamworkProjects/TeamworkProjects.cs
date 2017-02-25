namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TeamworkProjects
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new SortedDictionary<string, Team>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('-');

                if (!dict.ContainsKey(input[1]))
                {
                    var currentMember = new Team();
                    currentMember.Members = new List<string>();

                    currentMember.TeamName = input[1];
                    currentMember.Creator = input[0];
                    currentMember.Members.Add(string.Empty);
                    Console.WriteLine($"Team {currentMember.TeamName} has been created by {currentMember.Creator}!");
                    dict.Add(currentMember.TeamName, currentMember);
                }
                else if (dict.Any(x => x.Value.Creator.Equals(input[0])))
                {
                    Console.WriteLine($"{input[0]} cannot create another team!");
                }
                else
                {
                    Console.WriteLine($"Team {input[1]} was already created!");
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("end of assignment", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var line = input.Split('-', '>');

                if (!dict.ContainsKey(line[2]))
                {
                    Console.WriteLine($"Team {line[2]} does not exist!");
                }
                else if (dict.Any(x => x.Value.Creator.Equals(line[0])))
                {
                    Console.WriteLine($"Member {line[0]} cannot join team {dict[line[2]].TeamName}!");
                }
                else if (!dict.Any(x => x.Value.Members.Equals(line[0])))
                {
                    dict[line[2]].Members.Add(line[0]);
                }
                else
                {
                    Console.WriteLine($"Member {line[0]} cannot join team {line[2]}!");
                }
            }

            dict
                .OrderByDescending(x => x.Value.Members.Count)
                .ThenBy(x => x.Value.Members);

            foreach (var item in dict)
            {
                if (item.Value.Members.Count != 1)
                {
                    Console.WriteLine(item.Key);
                    Console.WriteLine($"- {item.Value.Creator}");
                    for (int i = 1; i < item.Value.Members.Count; i++)
                    {
                        Console.WriteLine($"-- {item.Value.Members[i]}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var item in dict)
            {
                if(item.Value.Members.Count == 1)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
