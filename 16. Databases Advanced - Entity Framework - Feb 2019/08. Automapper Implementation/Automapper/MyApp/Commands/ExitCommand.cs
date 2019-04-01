namespace MyApp.Commands
{
    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            return "exit";
        }
    }
}
