namespace FileDownloading
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncFileDownloader
    {
        private readonly string[] urls;
        private readonly int maxTreads;
        private readonly CountdownEvent countdown;
        private readonly SemaphoreSlim locker;
        private readonly ConcurrentDictionary<int, int> downloadPercentage;
        private readonly ConcurrentDictionary<int, long> downloadProgress;

        private long totalSize = 0L;
        private Timer timer;

        public AsyncFileDownloader(string[] urls)
        {
            this.urls = urls;
            this.maxTreads = 3;
            this.countdown = new CountdownEvent(this.urls.Length);
            this.locker = new SemaphoreSlim(this.maxTreads);
            this.downloadPercentage = new ConcurrentDictionary<int, int>();
            this.downloadProgress = new ConcurrentDictionary<int, long>();
        }

        public void Download()
        {
            Console.WriteLine("Starting download...");

            var localLocker = new object();

            Parallel.ForEach(this.urls,
                new ParallelOptions { MaxDegreeOfParallelism = this.maxTreads },
                localInit: () => 0L,
                body: (url, state, localTotal) => localTotal + this.GetFileSize(url),
                localFinally: (size) => { lock (localLocker) this.totalSize += size; });

            for (int i = 0; i < this.urls.Length; i++)
            {
                var url = this.urls[i];
                var fileOrder = i;

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
                    this.DownloadFile(url, fileOrder);
                });
            }
            
            this.StartReporting();

            this.countdown.Wait();

            this.timer.Dispose();

            this.ReportResults();
        }

        private void DownloadFile(string url, int fileOrder)
        {
            this.locker.Wait();

            try
            {
                var webClient = new WebClient();

                webClient.DownloadProgressChanged += (obj, progress) =>
                {
                    this.downloadPercentage[fileOrder] = progress.ProgressPercentage;
                    this.downloadProgress[fileOrder] = progress.BytesReceived;
                };

                webClient.DownloadFileCompleted += (obj, data) =>
                {
                    this.locker.Release();
                    this.countdown.Signal();
                };

                webClient.DownloadFileAsync(new Uri(url), fileOrder.ToString());
            }
            catch
            {
                this.locker.Release();
                this.countdown.Signal();
            }
        }

        private long GetFileSize(string url)
        {
            var webClient = new WebClient();

            using var readStream = webClient.OpenRead(url);

            return long.Parse(webClient.ResponseHeaders["Content-Length"]);
        }

        private void StartReporting()
        {
            this.timer = new Timer(_ =>
            {
                this.ReportResults();
            }, null, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1));
        }

        private void ReportResults()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            var totalDownloaded = this.downloadProgress.Values.Sum();
            var percentage = (double)totalDownloaded / this.totalSize * 100;

            var totalDownloadedInMb = totalDownloaded / 1024 / 1024;
            var totalSizeInMb = this.totalSize / 1024 / 1024;

            Console.Write($"Progress - {totalDownloadedInMb}/{totalSizeInMb} MB - {percentage:F2}%");

            foreach (var (key, value) in this.downloadPercentage)
            {
                Console.SetCursorPosition(0, key + 1);

                Console.Write($"{key} - {value}%");
            }
        }
    }
}
