namespace SoftUni.WebServer.Web
{
    using SoftUni.WebServer.Data;
    using SoftUni.WebServer.Mvc;
    using SoftUni.WebServer.Mvc.Routers;
    using SoftUni.WebServer.Server;

    public class Launcher
    {
        public static void Main()
        {
            var context = new WebServerContext();

            var server = new WebServer(
                42420,
                new ControllerRouter(),
                new ResourceRouter());

            MvcEngine.Run(server);
        }
    }
}
