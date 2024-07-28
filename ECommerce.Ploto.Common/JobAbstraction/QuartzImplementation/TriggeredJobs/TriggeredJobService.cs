using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation.TriggeredJobs
{
    public class TriggeredJobService : ITriggeredJobService
    {
        public Task FireAndForget(Type type, string jobName, DateTimeOffset fireAt, params (string key , string value)[] jobDetails)
        {
            var _scheduler = new StdSchedulerFactory().GetScheduler().Result;
            _scheduler.Start().Wait();


            var jobBuilder = JobBuilder.Create()
            .OfType(type)
            .WithIdentity(jobName);
            foreach (var item in jobDetails)
            {
                jobBuilder.UsingJobData(item.key, item.value);
            }

            IJobDetail jobDetail = jobBuilder.Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobName}_trigger")
                .StartAt(fireAt)
                .Build();

            _scheduler.ScheduleJob(jobDetail, trigger).Wait();
            return Task.CompletedTask;

        }
    }
}
