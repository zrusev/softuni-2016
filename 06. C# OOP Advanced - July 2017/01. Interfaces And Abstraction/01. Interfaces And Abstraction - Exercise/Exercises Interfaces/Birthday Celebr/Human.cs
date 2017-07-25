public class Human : ICitizen, IHuman, IBirthdate
{
    public Human(string id, string name, int age, string birthdate)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.Birthdate = birthdate;
    }

    public string Id { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Birthdate { get; private set; }
}