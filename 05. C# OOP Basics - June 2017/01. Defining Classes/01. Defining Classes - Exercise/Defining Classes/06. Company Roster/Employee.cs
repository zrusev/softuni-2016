namespace _06.Company_Roster
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public string Name { get => name; set => name = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public string Position { get => position; set => position = value; }
        public string Department { get => department; set => department = value; }
        public string Email { get => email; set => email = value; }
        public int Age { get => age; set => age = value; }

        public string PrintEmployeeInfo()
        {
            return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
        }
    }
}
