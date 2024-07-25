using ECommerce.Ploto.Common.JobAbstraction;
using ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation;
using Quartz;

namespace ECommerce.Ploto.WebAPI.Jobs
{
    [QuartzContinuousSchedulerJob("Test2", "0/5 * * ? * * *")]
    public class HelloWordJob : JobBase
    {
        //public Task Execute(IJobExecutionContext context)
        //{
        //    Console.WriteLine($"Hello world {context.JobDetail.Key.Name}");
        //    return Task.CompletedTask;
        //}


        public override Task JobService(IJobExecutionContext context)
        {
            Console.WriteLine($"Hello world {context.JobDetail.Key.Name}");

            return Task.CompletedTask;
        }
        }
}
