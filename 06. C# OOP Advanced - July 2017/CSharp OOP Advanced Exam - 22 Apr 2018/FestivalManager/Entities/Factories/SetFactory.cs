namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            if (!typeof(ISet).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{type}Command is not an ISet!");
            }

            object[] commandParrams = new object[] { name };

            return (ISet)Activator.CreateInstance(commandType, commandParrams);
        }
    }




}
