using ECommerce.Ploto.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Exception
{
    internal class RemoveDomainEventException : BaseException
    {
        internal RemoveDomainEventException(): base("there is not any Domain Event To Remove!")
        {
            
        }
    }
}
