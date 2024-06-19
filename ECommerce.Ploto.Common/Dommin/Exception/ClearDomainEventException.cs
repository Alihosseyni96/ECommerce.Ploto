using ECommerce.Ploto.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Exception
{
    internal class ClearDomainEventException : BaseException
    {
        public ClearDomainEventException(): base("Domain Event Is empty or Already Cleard")
        {
            
        }
    }
}
