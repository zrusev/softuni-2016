namespace MiniORM.App
{
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var connString = @"Data Source=(LocalDB)\LocalDB;Database=MiniORM;Integrated Security=SSPI;";

            var context = new SoftUniDbContext(connString);

            context.Employees.Add(new Employee
            {
                FirstName = "Pesho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();

            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
