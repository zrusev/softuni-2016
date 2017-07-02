using System.Collections.Generic;
using System.Linq;

namespace _06.Company_Roster
{
    public class Department
    {
        private Employee departmentMember;
        private List<Employee> departmentMembers;

        public Employee DepartmentMember { get => departmentMember; set => departmentMember = value; }
        public List<Employee> DepartmentMembers { get => departmentMembers; set => departmentMembers = value; }

        public Department()
        {
            this.departmentMembers = new List<Employee>();
        }

        public string CalculateDep()
        {
            var str = this.DepartmentMembers.GroupBy(x => x.Department).Select(g => new
                {
                    Name = g.Key,
                    Sal = g.Average(t => t.Salary)
                })
                .First().Name.ToString();
            return str;
        }


    }
}
