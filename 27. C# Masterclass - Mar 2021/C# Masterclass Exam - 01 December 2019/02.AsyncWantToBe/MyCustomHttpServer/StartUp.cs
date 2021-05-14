namespace MyCustomHttpServer
{   
    using System.Threading.Tasks;
    
    public static class StartUp
    {
        public static void Main()
            => Task.Run(async() => await new HttpServer()
                .StartAsync())
            .GetAwaiter()
            .GetResult();
    }
}