namespace MyApp.Core.ViewModels
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.ManagedEmployees = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmployeeDto> ManagedEmployees { get; set; }
    }
}