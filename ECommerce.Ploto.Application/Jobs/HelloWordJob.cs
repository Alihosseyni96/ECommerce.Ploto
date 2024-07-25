using ECommerce.Ploto.Common.JobAbstraction;
using ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Jobs
{
    [QuartzContinuousSchedulerJobAttribute("hello-world", "0/10 0 0 * * ?")]
    public class HelloWordJob : JobBase
    {
        public override Task JobService(IJobExecutionContext context)
        {
            Console.WriteLine($"Hello world {context.JobDetail.Key.Name}");

            return Task.CompletedTask;
            
        }
    }
}
