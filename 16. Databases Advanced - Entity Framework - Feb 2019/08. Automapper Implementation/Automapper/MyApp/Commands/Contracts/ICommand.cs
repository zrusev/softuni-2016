namespace MyApp.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(string[] inputArgs);
    }
}
