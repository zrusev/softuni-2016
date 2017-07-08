namespace _04.Average_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Average_Grades
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var currentStudent = new Student();
                double[] newArr = new double[input.Length - 1];
                for (int j = 1; j <= input.Length - 1; j++)
                {
                    newArr[j - 1] = double.Parse(input[j]);
                }
                currentStudent.name = input[0];
                currentStudent.grades = newArr;
                students.Add(currentStudent);
            }

            var newList = students
                .Where(x => x.avgGrade >= 5.0)
                .OrderBy(x => x.name)
                .ThenByDescending(x => x.avgGrade);

            foreach (var item in newList)
            {
                Console.WriteLine($"{item.name} -> {item.avgGrade:F2}");
            }
        }
    }
}
