using ECommerce.Ploto.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Exception.Base
{
    public class DomainException : BaseException
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
