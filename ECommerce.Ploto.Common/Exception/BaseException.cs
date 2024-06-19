using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Exception
{
    public class BaseException : ApplicationException 
    {
        public BaseException(string message) : base(message) 
        {
            
        }
    }
}
