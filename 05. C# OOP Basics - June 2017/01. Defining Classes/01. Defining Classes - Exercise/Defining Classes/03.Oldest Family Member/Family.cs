using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03.Oldest_Family_Member
{
    public class Family
    {
        private List<Person> people;
        private Person member;

        public List<Person> People { get => people; set => people = value; }
        public Person Member { get => member; set => member = value; }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person person = people.OrderByDescending(x => x.Age).First();
            return person;
        }

        public Family()
        {
            this.people = new List<Person>();
        }
        
    }
}
