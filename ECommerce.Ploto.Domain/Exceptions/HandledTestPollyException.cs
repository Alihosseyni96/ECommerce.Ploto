using ECommerce.Ploto.Common.Dommin.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Exceptions
{
    public class HandledTestPollyException : DomainException
    {
        public HandledTestPollyException(string message) : base(message)
        {
        }
    }
}
