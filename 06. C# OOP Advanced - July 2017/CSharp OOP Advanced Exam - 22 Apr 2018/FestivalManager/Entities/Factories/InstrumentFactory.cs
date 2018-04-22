namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            if (!typeof(IInstrument).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{type}Command is not an ISet!");
            }

            return (IInstrument)Activator.CreateInstance(commandType);
        }
	}
}