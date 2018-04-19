namespace Forum.App.Commands
{
    using Contracts;
    public class LogInMenuCommand : NavigationCommand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
