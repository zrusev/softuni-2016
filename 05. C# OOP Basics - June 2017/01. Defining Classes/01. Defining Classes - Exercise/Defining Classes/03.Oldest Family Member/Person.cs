using System.Data;

namespace _03.Oldest_Family_Member
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person()
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
