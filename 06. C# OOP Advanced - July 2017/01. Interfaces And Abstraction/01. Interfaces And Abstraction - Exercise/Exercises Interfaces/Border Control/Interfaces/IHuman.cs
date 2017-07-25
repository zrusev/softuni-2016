namespace Border_Control.Interfaces
{
    public interface IHuman : ICitizen
    {
        string Name { get; }

        int Age { get; }
    }
}