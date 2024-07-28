using ECommerce.Ploto.Common.JobAbstraction;
using ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation;
using Quartz;

namespace ECommerce.Ploto.WebAPI.Jobs
{
    //[QuartzContinuousSchedulerJob("Hello-world", "0/2 * * * * ?")]
    public class HelloWorldJob : JobBase
    {
        public override Task JobService(IJobExecutionContext context)
        {
            Console.WriteLine("Hello world");
            return Task.CompletedTask;
        }
    }
}
