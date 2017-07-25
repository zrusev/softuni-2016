public interface IHuman : ICitizen, IBirthdate
{
    string Name { get; }

    int Age { get; }
}