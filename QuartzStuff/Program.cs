using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();

            var a = new Dictionary<string, Hobject>();
            a.Add("Name", new Hobject() { stringarray = new string[] { "asd" } });
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("name", "group")
                .UsingJobData(new JobDataMap(a))
                .Build();

            IJobDetail job2 = JobBuilder.Create<HelloJob>()
                .WithIdentity("name2", "group")
                .UsingJobData(new JobDataMap(a))
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromMilliseconds(1000)).WithRepeatCount(5))
                .StartNow()
                .Build();
            ITrigger trigger2 = TriggerBuilder.Create()
                .WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromMilliseconds(1000)).RepeatForever())
                .StartNow()
                .Build();

            scheduler.ScheduleJob(job, trigger);
            scheduler.Start();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            scheduler.Shutdown();
        }
    }

    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Job executing...{DateTime.UtcNow.Millisecond}  {((Hobject)context.JobDetail.JobDataMap.Get("Name")).stringarray[0]}");
        }
    }
}
