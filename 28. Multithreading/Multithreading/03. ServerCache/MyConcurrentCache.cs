namespace MyCache
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyConcurrentCache
    {
        private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
        private readonly ConcurrentDictionary<string, object> cache;
        private readonly ConcurrentDictionary<string, SemaphoreSlim> lockers; 

        public MyConcurrentCache()
        {
            this.cache = new ConcurrentDictionary<string, object>();
            this.lockers = new ConcurrentDictionary<string, SemaphoreSlim>();
        }

        public TItem GetOrCreate<TItem>(string key, Func<TItem> createItem)
            where TItem : class
        {
            //try
            //{
            //    Locker.EnterUpgradeableReadLock();

            //    if (!this.cache.ContainsKey(key))
            //    {
            //        Locker.EnterWriteLock();
            //        this.cache.TryAdd(key, createItem);
            //        Locker.ExitWriteLock();
            //    }

            //    return (TItem)this.cache[key];
            //}
            //finally
            //{
            //    Locker.ExitUpgradeableReadLock();
            //}

            if (!this.cache.TryGetValue(key, out var item))
            {
                var lockForKey = this.lockers.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));

                lockForKey.Wait();

                try
                {
                    item = this.cache.GetOrAdd(key, _ => createItem());
                }
                finally
                {
                    lockForKey.Release();
                }
            }

            return item as TItem;
        }

        public async Task<TItem> GetOrCreateAsync<TItem>(string key, Func<Task<TItem>> createItem)
            where TItem : class
        {
            if (!this.cache.TryGetValue(key, out var item))
            {
                var lockForKey = this.lockers.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));

                await lockForKey.WaitAsync();

                try
                {
                    if (!this.cache.TryGetValue(key, out item))
                    {
                        var value = await createItem();
                        this.cache.TryAdd(key, value);
                    }
                }
                finally
                {
                    lockForKey.Release();
                }
            }

            return item as TItem;
        }
    }
}
