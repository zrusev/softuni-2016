namespace MyCache
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyCache
    {
        private readonly SemaphoreSlim semaphoreLocker = new SemaphoreSlim(1,1);
        private readonly Dictionary<string, object> cache;

        public MyCache()
        {
            this.cache = new Dictionary<string, object>();
        }

        public TItem GetOrCreate<TItem>(string key, Func<TItem> createItem)
            where TItem : class
        {
            this.semaphoreLocker.Wait();

            try
            {
                if (!this.cache.ContainsKey(key))
                {
                    this.cache.Add(key, createItem);
                }
            }
            finally
            {
                this.semaphoreLocker.Release();
            }

            return this.cache[key] as TItem;
        }

        public async Task<TItem> GetOrCreateAsync<TItem>(string key, Func<Task<TItem>> createItem)
            where TItem : class
        {
            try
            {
                await this.semaphoreLocker.WaitAsync();

                if (!this.cache.ContainsKey(key))
                {
                    this.cache.Add(key, createItem);
                }
            }
            finally
            {
                this.semaphoreLocker.Release();
            }

            return this.cache[key] as TItem;
        }
    }
}
