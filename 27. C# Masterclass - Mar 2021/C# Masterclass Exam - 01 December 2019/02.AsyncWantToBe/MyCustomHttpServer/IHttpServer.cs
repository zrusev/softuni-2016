namespace MyCustomHttpServer
{
    using System.Threading.Tasks;

    public interface IHttpServer
    {
        void Start();

        Task StartAsync();

        void Stop();
    }
}