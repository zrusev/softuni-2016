namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class MentorGroup
    {
        static void Main()
        {
            var dict = new SortedDictionary<string, Student>();

            while (true)
            {

                var input = Console.ReadLine();
                if (input.Equals("end of dates", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var firstLine = input.Split(' ', ',');
                var currentStudent = new Student();
                currentStudent.Attendance = new List<DateTime>();
                currentStudent.Name = firstLine[0];

                if (firstLine.Length > 0)
                {
                    for (int i = 1; i < firstLine.Length; i++)
                    {
                        currentStudent.Attendance.Add(DateTime.ParseExact(firstLine[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                    currentStudent.Attendance.Sort((a, b) => a.CompareTo(b));
                }

                if (!dict.ContainsKey(currentStudent.Name))
                {
                    dict.Add(currentStudent.Name, currentStudent);
                }
                else
                {
                    dict[currentStudent.Name].Attendance.AddRange(currentStudent.Attendance);
                    dict[currentStudent.Name].Attendance.Sort((a, b) => a.CompareTo(b));
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("end of comments", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var secondLine = input.Split('-');
                var currentStudent = new Student();
                currentStudent.Comments = new List<string>();
                currentStudent.Name = secondLine[0];

                if (secondLine.Length > 0)
                {
                    currentStudent.Comments.Add(secondLine[1]);
                }

                if (dict.ContainsKey(currentStudent.Name) && dict[currentStudent.Name].Comments == null)
                {
                    dict[currentStudent.Name].Comments = currentStudent.Comments;
                }
                else if (dict.ContainsKey(currentStudent.Name) && dict[currentStudent.Name].Comments != null)
                {
                    dict[currentStudent.Name].Comments.AddRange(currentStudent.Comments);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("Comments:");
                if (item.Value.Comments != null)
                {
                    foreach (var cm in item.Value.Comments)
                    {
                        Console.WriteLine($"- {cm}");
                    }
                }
                Console.WriteLine("Dates attended:");
                foreach (var dt in item.Value.Attendance)
                {
                    Console.WriteLine($"-- {dt.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }
}
