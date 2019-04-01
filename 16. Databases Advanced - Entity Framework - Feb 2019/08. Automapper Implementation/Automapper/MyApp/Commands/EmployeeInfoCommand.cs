namespace MyApp.Commands
{
    using AutoMapper;
    using Commands.Contracts;
    using Core.ViewModels;
    using Data;
    using Models;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);

            //TODO validate

            Employee employee = this.context.Employees
                .Find(employeeId);

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"ID: {employeeId} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}";
        }
    }
}
