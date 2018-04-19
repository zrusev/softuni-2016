namespace Forum.App.Commands
{
    using Contracts;
    public class SignUpMenuCommand : NavigationCommand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}
