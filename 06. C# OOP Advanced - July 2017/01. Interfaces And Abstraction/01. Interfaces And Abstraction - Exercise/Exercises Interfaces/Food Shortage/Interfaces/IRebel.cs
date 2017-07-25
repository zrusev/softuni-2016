namespace Food_Shortage.Interfaces
{
    public interface IRebel : IBuyer
    {
        string Name { get; }

        int Age { get; }

        string Group { get; }
    }
}