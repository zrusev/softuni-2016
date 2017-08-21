namespace _04.Work
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            IList<IEmployee> employees = new List<IEmployee>();
            JobList jobs = new JobList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                IEmployee emp = null;

                switch (tokens[0])
                {
                    case "Job":
                        emp = employees.First(e => e.Name == tokens[3]);
                        Job job = new Job(tokens[1], int.Parse(tokens[2]), emp);
                        job.JobDone += jobs.HandleJobCompletion;
                        jobs.Add(job);
                        break;

                    case "StandartEmployee":
                        emp = new StandartEmployee(tokens[1]);
                        employees.Add(emp);
                        break;

                    case "PartTimeEmployee":
                        emp = new PartTimeEmployee(tokens[1]);
                        employees.Add(emp);
                        break;

                    case "Pass":
                        List<Job> dummyJobs = new List<Job>(jobs);
                        foreach (var j in dummyJobs)
                        {
                            j.Update();
                        }
                        break;

                    case "Status":
                        jobs.ForEach(j => Console.WriteLine(j));
                        break;

                    default:
                        break;
                }
            }
        }

        public delegate void JobDoneHandler(object sender, JobEventArgs args);

        public class Job
        {
            public event JobDoneHandler JobDone;

            private IEmployee employee;

            public Job(string name, int hoursOfWork, IEmployee employee)
            {
                this.Name = name;
                this.HoursOfWork = hoursOfWork;
                this.employee = employee;
            }

            public string Name { get; private set; }
            public int HoursOfWork { get; set; }

            public void Update()
            {
                this.HoursOfWork -= this.employee.WorkHours;
                if (this.HoursOfWork <= 0)
                {
                    Console.WriteLine($"Job {this.Name} done!");
                    this.OnJobDone(new JobEventArgs(this));
                }
            }

            private void OnJobDone(JobEventArgs args)
            {
                this.JobDone?.Invoke(this, args);
            }

            public override string ToString()
            {
                return $"Job: {this.Name} Hours Remaining: {this.HoursOfWork}";
            }
        }
        public class JobEventArgs : EventArgs
        {
            public JobEventArgs(Job job)
            {
                this.Job = job;
            }

            public Job Job { get; protected set; }
        }

        public class JobList : List<Job>
        {
            public void HandleJobCompletion(object sender, JobEventArgs args)
            {
                this.Remove(args.Job);
            }
        }
        public class PartTimeEmployee : IEmployee
        {
            public PartTimeEmployee(string name)
            {
                this.Name = name;
                this.WorkHours = 20;
            }

            public string Name { get; private set; }

            public int WorkHours { get; private set; }
        }
        public class StandartEmployee : IEmployee
        {
            public StandartEmployee(string name)
            {
                this.Name = name;
                this.WorkHours = 40;
            }

            public string Name { get; private set; }

            public int WorkHours { get; private set; }
        }
        public interface IEmployee
        {
            string Name { get; }

            int WorkHours { get; }
        }
    }
}
