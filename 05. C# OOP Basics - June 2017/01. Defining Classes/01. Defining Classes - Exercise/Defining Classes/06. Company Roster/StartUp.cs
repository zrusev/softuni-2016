using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.Company_Roster
{
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var members = new Department();
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var employee = new Employee();
                employee.Name = input[0];
                employee.Salary = decimal.Parse(input[1]);
                employee.Position = input[2];
                employee.Department = input[3];
                if (input.Length == 5)
                {
                    if (Regex.IsMatch(input[4], @"^\d+$"))
                    {
                        employee.Age = int.Parse(input[4]);
                        employee.Email = "n/a";
                    }
                    else
                    {
                        employee.Email = input[4];
                        employee.Age = -1;
                    }
                }
                else if (input.Length == 6)
                {
                    if (Regex.IsMatch(input[4], @"^\d+$"))
                    {
                        employee.Age = int.Parse(input[4]);
                        employee.Email = input[5];
                    }
                    else
                    {
                        employee.Age = int.Parse(input[5]);
                        employee.Email = input[4];
                    }
                }
                else
                {
                    employee.Age = -1;
                    employee.Email = "n/a";
                }

                members.DepartmentMember = employee;
                members.DepartmentMembers.Add(members.DepartmentMember);
            }

            var departments = members.DepartmentMembers.GroupBy(x => x.Department)
                .Select(gr => new
                {
                    Name = gr.Key,
                    AverageSalary = gr.Average(g => g.Salary),
                    Employee = gr
                })
                .OrderByDescending(gr => gr.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {departments.Name}");
            foreach (var emp in departments.Employee.OrderByDescending(em => em.Salary))
            {
                Console.WriteLine(emp.PrintEmployeeInfo());
            }
        }
    }
}
