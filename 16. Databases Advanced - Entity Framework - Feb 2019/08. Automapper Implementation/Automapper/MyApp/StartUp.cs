namespace MyApp
{
    using AutoMapper;
    using Core;
    using Core.Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider services = ConfigureServices();
            IEngine engine = new Engine(services);
            engine.Run();

            //Database
            //Command pattern
            //DI
            //DTOs
            //Service Layer
            
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MyAppContext>(db =>
                db.UseSqlServer(@"Server=Data Source=(LocalDB)\LocalDB;Database=AutomapperApp;Integrated Security=SSPI;"));
            
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<Mapper>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}