namespace MyApp.Commands
{
    using AutoMapper;
    using Contracts;
    using Core.ViewModels;
    using Data;
    using System;

    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var birthDate = DateTime.Parse(inputArgs[1]);

            //TODO validate

            var employee = this.context.Employees.Find(employeeId);
            employee.Birthday = birthDate;

            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"Employee: {employeeDto.LastName} birthday:  {employeeDto.Birthday} updated successfully!";
        }
    }
}
