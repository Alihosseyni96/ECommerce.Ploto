using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation
{
    public class QuartzContinuousSchedulerJobAttribute : Attribute
    {
        public string JobName { get; set; }
        public string Schedule { get; set; }
        public QuartzContinuousSchedulerJobAttribute(string jobName, string schedule )
        {
            JobName = jobName;
            Schedule = schedule;
        }

    }

}
