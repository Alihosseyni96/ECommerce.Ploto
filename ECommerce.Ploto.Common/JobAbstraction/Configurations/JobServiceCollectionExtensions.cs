using ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation;
using ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation.TriggeredJobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.JobAbstraction.Configurations
{
    public static  class JobServiceCollectionExtensions
    {
        public static IServiceCollection AddJobAbstraction(this IServiceCollection services , Action<JobConfig> action)
        {
            var config = new JobConfig(services);
            action(config);
            return services;
        }



        public class JobConfig
        {
            private readonly IServiceCollection _services;
            public JobConfig(IServiceCollection services)
            {
                _services = services;
            }




            public void UseQuartz(Action<QuartzOptions> action)
            {
                var options = new QuartzOptions();
                action(options);

                _services.AddSingleton<ITriggeredJobService, TriggeredJobService>();


                var types = options.Assembly
                    .GetTypes()
                    .Where(type => type.GetCustomAttribute<QuartzContinuousSchedulerJobAttribute>() != null);

                foreach (var type in types)
                {
                    Start(type);
                }


                //return this;


                void Start(Type type)
                {
                    var _scheduler = new StdSchedulerFactory().GetScheduler().Result;
                    _scheduler.Start().Wait();


                    var attribute = type.GetCustomAttribute<QuartzContinuousSchedulerJobAttribute>();

                    if(attribute != null)
                    {
                        // Define the job
                        var jobDetail = JobBuilder.Create()
                                    .OfType(type)
                                    .WithIdentity(attribute.JobName)
                                    .Build();

                        var trigger = TriggerBuilder.Create()
                            .WithIdentity($"{attribute.JobName}_trigger")
                            .WithCronSchedule(attribute.Schedule)
                            .Build();

                        _scheduler.ScheduleJob(jobDetail, trigger).Wait();

                    }

                }

            }


            public JobConfig UseHangFire()
            {
                throw new NotImplementedException();
            }




        }
    }






}
