namespace Forum.App.Commands
{
    using Contracts;
    using Forum.App.Menus;

    public class LogInCommand : ICommand
    {
        private const string errorMessage = "Invalid username or password!";

        private IUserService userService;
        private IMenuFactory menuFactory;

        public LogInCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool validUsername = !string.IsNullOrEmpty(username) && username.Length >= 4;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length >= 4;

            if (!validUsername || !validPassword)
            {
                throw new System.ArgumentException(errorMessage);
            }

            bool userLoggedIn = this.userService.TryLogInUser(username, password);

            if (!userLoggedIn)
            {
                throw new System.InvalidOperationException("Username already taken!");
            }

            return this.menuFactory.CreateMenu(nameof(MainMenu));
        }
    }
}
