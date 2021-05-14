namespace MyCustomHttpServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpServer : IHttpServer
    {
        private bool isWorking;
        private readonly TcpListener tcpListener;
        private readonly StringWriter writer;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
            this.writer = new StringWriter();
        }
        
        public void Start()
        {
            this.tcpListener.Start();

            this.isWorking = true;

            Console.WriteLine("Started.");

            while (this.isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                var buffer = new byte[1024];
                var stream = client.GetStream();
                var readLength = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
                
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);
                
                var responseText = File.ReadAllText("index.html");
                var responseBytes = Encoding.UTF8.GetBytes(
                    "HTTP/1.0 200 Not Found" + Environment.NewLine +
                    "Content-Length: " + responseText.Length + Environment.NewLine + Environment.NewLine +
                    responseText);
                stream.Write(responseBytes);
            }
        }

        public async Task StartAsync()
        {
            await Task.Run(() =>
            {
                this.tcpListener.Start();

                this.isWorking = true;

                Console.WriteLine("Started.");
            });

            while (this.isWorking)
            {
                var client = await this.tcpListener.AcceptTcpClientAsync();
                
                var buffer = new byte[1024];
                var stream = await Task.Run(() => client.GetStream());

                var readLength = await stream.ReadAsync(buffer, 0, buffer.Length);

                await Task.Run(() =>
                {
                    var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);

                    Console.WriteLine(new string('=', 60));
                    Console.WriteLine(requestText);
                });

                await GetResponse(stream); 
            }
        }

        private async Task GetResponse(NetworkStream stream)
        {
            var responseText = await File.ReadAllTextAsync("index.html");
            var responseBytes = Encoding.UTF8.GetBytes(
                "HTTP/1.0 200 Not Found" + Environment.NewLine +
                "Content-Length: " + responseText.Length + Environment.NewLine + Environment.NewLine +
                responseText);

            await stream.WriteAsync(responseBytes);
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}