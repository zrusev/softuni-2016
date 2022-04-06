namespace MyCache
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            await ValidateSyncCache();
            await ValidateAsyncCache();
            ValidateSyncLongOperation();
            ValidateAsyncLongOperation();
        }

        private static async Task ValidateSyncCache()
        {
            var myCache = new MyCache();

            var tasks = new List<Task>();

            var count = 0;

            for (var i = 1; i < 10; i++)
            {
                var current = i;

                tasks.Add(Task.Run(() =>
                {
                    var currentValue = new string('-', current);
                    var result = myCache.GetOrCreate("Key", () => currentValue);

                    if (currentValue == result)
                    {
                        Interlocked.Increment(ref count);
                    }
                }));
            }

            await Task.WhenAll(tasks);

            if (count > 1)
            {
                throw new InvalidOperationException("Race condition occured in the cache!");
            }
        }

        public static async Task ValidateAsyncCache()
        {
            var myCache = new MyCache();

            var tasks = new List<Task>();

            var count = 0;

            for (var i = 1; i < 10; i++)
            {
                var current = i;

                tasks.Add(Task.Run(async () =>
                {
                    var currentValue = new string('-', current);
                    var result = await myCache.GetOrCreateAsync("Key", () => Task.FromResult(currentValue));

                    if (currentValue == result)
                    {
                        Interlocked.Increment(ref count);
                    }
                }));
            }

            await Task.WhenAll(tasks);

            if (count > 1)
            {
                throw new InvalidOperationException("Race condition occured in the cache!");
            }
        }

        public static void ValidateSyncLongOperation()
        {
            var myCache = new MyConcurrentCache();

            var firstThread = new Thread(() =>
            {
                myCache.GetOrCreate("Key", () =>
                {
                    Thread.Sleep(4000);
                    return "FirstTask";
                });
            });

            var secondThread = new Thread(() =>
            {
                Thread.Sleep(1000);
                var result = myCache.GetOrCreate("Key", () => "SecondTask");
                if (result == "SecondTask")
                {
                    throw new InvalidOperationException("Long operations are not awaited!");
                }
            });

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();
        }

        public static void ValidateAsyncLongOperation()
        {
            var myCache = new MyConcurrentCache();

            var firstThread = new Thread(async () =>
            {
                await myCache.GetOrCreateAsync("Key", () =>
                {
                    Thread.Sleep(4000);
                    return Task.FromResult("FirstTask");
                });
            });

            var secondThread = new Thread(async () =>
            {
                Thread.Sleep(1000);
                var result = await myCache.GetOrCreateAsync("Key", () => Task.FromResult("SecondTask"));
                if (result == "SecondTask")
                {
                    throw new InvalidOperationException("Long operations are not awaited!");
                }
            });

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();
        }
    }
}
