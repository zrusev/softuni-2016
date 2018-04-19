namespace Forum.App.Commands
{
    using Contracts;
    using Menus;
    public class SignUpCommand : ICommand
    {
        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
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
                throw new System.ArgumentException("Invalid username or password!");
            }

            bool userSignedUp = this.userService.TrySignUpUser(username, password);

            if (!userSignedUp)
            {
                throw new System.InvalidOperationException("Username already taken!");
            }

            return this.menuFactory.CreateMenu(nameof(MainMenu));
        }
    }
}
