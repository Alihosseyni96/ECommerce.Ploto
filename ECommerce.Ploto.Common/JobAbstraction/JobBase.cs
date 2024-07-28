using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.JobAbstraction
{
    public abstract class JobBase : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                BeforeExecute(context);
                await JobService(context);
                AfterExecute(context);
            }
            catch (System.Exception e)
            {
                OnException(context , e);
                throw new JobExecutionException(e);
            }
            Task.CompletedTask.Wait();

        }


        private void BeforeExecute(IJobExecutionContext context)
        {
            Console.WriteLine($"job:{context.JobDetail.Key.Name} will be running");
            //_logger.LogInformation($"job {context.JobDetail.Key.Name} will be running");
        }

        private void AfterExecute(IJobExecutionContext context)
        {
            Console.WriteLine($"job:{context.JobDetail.Key.Name} fired successfully");
            //_logger.LogInformation($"job{context.JobDetail.Key.Name} fired successfully");
        }

        private void OnException(IJobExecutionContext context , System.Exception e)
        {
            Console.WriteLine($"job:{context.JobDetail.Key.Name} faield");
            //_logger.LogError($"job {context.JobDetail.Key.Name} faild with message {e.Message}");
        }

        public abstract Task JobService(IJobExecutionContext context);


    }
}
