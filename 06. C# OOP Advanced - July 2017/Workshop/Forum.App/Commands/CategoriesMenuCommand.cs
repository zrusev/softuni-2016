namespace Forum.App.Commands
{
    using Contracts;
    public class CategoriesMenuCommand : NavigationCommand
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        {
        }
    }
}
