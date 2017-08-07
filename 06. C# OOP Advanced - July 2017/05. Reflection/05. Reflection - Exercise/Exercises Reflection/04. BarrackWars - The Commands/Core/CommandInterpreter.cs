using System;
using System.CodeDom;
using System.Globalization;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private IRepository repository;
        private IUnitFactory uniteFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory uniteFactory)
        {
            this.repository = repository;
            this.uniteFactory = uniteFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandCompleteName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            Type commandType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == commandCompleteName);

            object[] commandParrams =
            {
                data,
                this.repository,
                this.uniteFactory
            };

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return (IExecutable)Activator.CreateInstance(commandType, commandParrams);
        }
    }
}