namespace MyApp.Core.ViewModels
{
    using MyApp.Models;
    using System;

    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public int Id { get; set; }

        public string  FirstName { get; set; }

        public string  LastName { get; set; }

        public decimal  Salary { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
    }
}