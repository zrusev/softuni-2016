namespace MyApp.Commands
{
    using AutoMapper;
    using Contracts;
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var age = int.Parse(inputArgs[0]);
            
            var employees = this.context.Employees
                .Where(e => e.Birthday.Value.AddYears(age) <= DateTime.Now)
                .OrderByDescending(s => s.Salary)
                .ToList();

            //var employeeDto = this.mapper.CreateMappedObject<List<EmployeeDto>>(employees);

            StringBuilder sb = new StringBuilder();
            
            foreach (var item in employees)
            {
                string manager;
                
                if (item.Manager is null)
                {
                    manager = "no manager";
                }
                else
                {
                    manager = item.Manager.LastName;
                }

                sb.AppendLine($"{item.FirstName} {item.LastName} -${item.Salary:F2} - Manager: [{manager}]");
            }

            return sb.ToString();
        }
    }
}
