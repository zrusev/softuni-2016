namespace MyApp.Core
{
    using Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IServiceProvider provider;

        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                var commandInterpreter = this.provider.GetService<ICommandInterpreter>();
                string result = commandInterpreter.Read(inputArgs);
                
                if (result == "exit")
                {
                    Environment.Exit(-1);
                }

                Console.WriteLine(result);

                //TODO add try catch block
            }
        }
    }
}
