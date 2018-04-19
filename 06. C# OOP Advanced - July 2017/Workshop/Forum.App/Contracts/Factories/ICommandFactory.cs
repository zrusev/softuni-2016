namespace Forum.App.Contracts
{
    using System;
    public interface ICommandFactory
    {
		ICommand CreateCommand(string commandName);
    }
}
