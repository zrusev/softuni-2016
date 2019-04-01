namespace MyApp.Commands
{
    using AutoMapper;
    using Contracts;
    using Core.ViewModels;
    using Data;

    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var employeeId = int.Parse(inputArgs[0]);
            var address = inputArgs[1];

            //TODO validate

            var employee = this.context.Employees.Find(employeeId);
            employee.Address = address;

            context.SaveChanges();
            
            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"Employee: {employeeDto.LastName} address: {employeeDto.Address} updated successfully!";
        }
    }
}
