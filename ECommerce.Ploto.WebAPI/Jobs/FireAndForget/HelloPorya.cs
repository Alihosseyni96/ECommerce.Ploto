using ECommerce.Ploto.Common.JobAbstraction;
using Quartz;

namespace ECommerce.Ploto.WebAPI.Jobs.FireAndForget
{
    public class HelloPorya : JobBase
    {
        public override Task JobService(IJobExecutionContext context)
        {
            Console.WriteLine($"Hello {context.JobDetail.JobDataMap.GetString("name")}");
            return Task.CompletedTask;
        }

    }
}

