namespace FolderSync
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading;

    public class BlockingCollectionFolderSynchronizer
    {
        private readonly string source;
        private readonly string destination;

        private readonly BlockingCollection<WorkItem> jobs;
        private readonly FileSystemWatcher watcher;
        private readonly ConcurrentDictionary<Guid, int> retries;

        private readonly int maxThreads;

        public BlockingCollectionFolderSynchronizer(string sourcePath, string destinationPath)
        {
            this.source = sourcePath;
            this.destination = destinationPath;

            this.jobs = new BlockingCollection<WorkItem>();
            this.watcher = new FileSystemWatcher
            {
                Path = this.source
            };
            this.retries = new ConcurrentDictionary<Guid, int>();

            this.maxThreads = Environment.ProcessorCount / 2;
        }


        private void InitializeJobs()
        {
            for (int i = 0; i < this.maxThreads; i++)
            {
                Thread thread = new Thread(() =>
                {
                    while (true)
                    {
                        if (this.jobs.IsCompleted)
                        {
                            return;
                        }

                        this.ProcesFile();
                    }
                })
                {
                    Priority = ThreadPriority.BelowNormal
                };

                thread.Start();
            }
        }

        private void ProcesFile()
        {
            foreach (var workitem in this.jobs.GetConsumingEnumerable())
            {
                try
                {
                    workitem.Action();
                }
                catch
                {
                    var value = this.retries.GetOrAdd(workitem.Id, _ => 0);

                    if (value > 3)
                    {
                        if (!this.jobs.IsAddingCompleted)
                        {
                            this.jobs.Add(workitem);
                        }

                        this.retries[workitem.Id]++;
                    }
                }
            }
        }

        public void Start()
        {
            this.InitializeWatcher();
            this.InitializeJobs();
        }

        public void Stop()
        {
            this.watcher.EnableRaisingEvents = false;
            this.jobs.CompleteAdding();
        }

        private void InitializeWatcher()
        {
            this.InitializeCreatedEvent();
            this.InitializeRenamedEvent();
            this.InitializeChangedEvent();
            this.InitializeDeletedEvent();

            this.watcher.IncludeSubdirectories = true;
            this.watcher.EnableRaisingEvents = true;
        }

        private void InitializeCreatedEvent()
        {
            this.watcher.Created += (obj, data) =>
            {
                this.jobs.Add(new WorkItem(() =>
                {
                    var path = Path.GetRelativePath(this.source, data.FullPath);

                    var destinationPath = Path.Combine(this.destination, path);

                    if (Directory.Exists(data.FullPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }
                    else
                    {
                        File.Copy(data.FullPath, destinationPath);
                    }

                    Console.WriteLine($"Copied '{path}'.");
                }));
            };
        }

        private void InitializeRenamedEvent()
        {
            this.watcher.Renamed += (obj, data) =>
            {
                this.jobs.Add(new WorkItem(() =>
                {
                    var oldPath = Path.GetRelativePath(this.source, data.OldFullPath);
                    var newPath = Path.GetRelativePath(this.source, data.FullPath);

                    var destinationOldPath = Path.Combine(this.destination, oldPath);
                    var destinationNewPath = Path.Combine(this.destination, newPath);

                    if (Directory.Exists(destinationOldPath))
                    {
                        Directory.Move(destinationOldPath, destinationNewPath);
                    }
                    else
                    {
                        File.Move(destinationOldPath, destinationNewPath);
                    }

                    Console.WriteLine($"Renamed '{oldPath}' to '{newPath}'.");
                }));
            };
        }

        private void InitializeChangedEvent()
        {
            this.watcher.Changed += (obj, data) =>
            {
                this.jobs.Add(new WorkItem(() =>
                {
                    var path = Path.GetRelativePath(this.source, data.FullPath);

                    var destinationPath = Path.Combine(this.destination, path);

                    if (!Directory.Exists(data.FullPath))
                    {
                        File.Copy(data.FullPath, destinationPath, true);

                        Console.WriteLine($"Updated '{path}'.");
                    }
                }));
            };
        }

        private void InitializeDeletedEvent()
        {
            this.watcher.Deleted += (obj, data) =>
            {
                this.jobs.Add(new WorkItem(() =>
                {
                    var path = Path.GetRelativePath(this.source, data.FullPath);

                    var destinationPath = Path.Combine(this.destination, path);

                    if (Directory.Exists(data.FullPath))
                    {
                        Directory.Delete(destinationPath);
                    }
                    else
                    {
                        File.Delete(destinationPath);
                    }

                    Console.WriteLine($"Deleted '{path}'.");
                }));
            };
        }

        private class WorkItem
        {
            public WorkItem(Action action)
            {
                this.Action = action;
                this.Id = Guid.NewGuid();
            }

            public Guid Id { get; }

            public Action Action { get; }
        }
    }
}
