using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation.TriggeredJobs
{
    public interface ITriggeredJobService
    {
        Task FireAndForget(Type type, string jobName, DateTimeOffset fireAt, params (string key, string value)[] jobDetails);
    }
}
