using System.Collections.Generic;
using System.Linq;

namespace _13.Family_Tree
{
    public class Person
    {
        private List<Person> childen;

        public Person()
        {
            this.childen = new List<Person>();
        }

        public Person(string name, string date)
            :this()
        {
            this.Name = name;
            this.BirthDate = date;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }

        public IReadOnlyList<Person> Children
        {
            get { return this.childen.AsReadOnly(); }
        }

        public void AddChild(Person child)
        {
            this.childen.Add(child);
        }
        
        public void AddChildrenInfo(string name, string date)
        {
            if(this.childen.FirstOrDefault(c => c.Name == name) != null)
            {
                this.childen.FirstOrDefault(c => c.Name == name).BirthDate = date;
                return;
            }

            if (this.childen.FirstOrDefault(c => c.BirthDate == date) != null)
            {
                this.childen.FirstOrDefault(c => c.BirthDate == date).Name = name;
            }
        }

        public Person FindChildName(string childName)
        {
            return this.childen.FirstOrDefault(c => c.Name == childName);
        }
    }
}
