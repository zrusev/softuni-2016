namespace Food_Shortage.Interfaces
{
    public interface ICitizen : IIdentify, IBuyer, IBirthdate
    {
        string Name { get; }

        int Age { get; }
    }
}