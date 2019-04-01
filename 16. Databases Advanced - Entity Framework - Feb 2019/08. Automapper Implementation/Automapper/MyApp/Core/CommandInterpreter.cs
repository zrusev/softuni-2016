namespace MyApp.Core
{
    using Commands.Contracts;
    using Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] inputArgs)
        {
            //type 
            //ctor
            //ctro params
            //invoke
            //execute
            //return result

            //AddEmployee + Command
            string commandName = inputArgs[0] + Suffix; 
            string[] commandParams = inputArgs.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            if (type == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            var constructor = type.GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();
            
            var command = (ICommand)constructor
                .Invoke(services);

            string result = command.Execute(commandParams);

            return result;
        }
    }
}