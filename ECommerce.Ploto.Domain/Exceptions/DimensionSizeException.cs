using ECommerce.Ploto.Common.Dommin.Exception.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Exceptions
{
    public class DimensionSizeException : DomainException
    {
        public DimensionSizeException():base("Invalid Size ")
        {
            
        }
    }
}
