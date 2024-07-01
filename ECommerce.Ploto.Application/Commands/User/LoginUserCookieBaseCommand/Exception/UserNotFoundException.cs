using ECommerce.Ploto.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand.Exception
{
    public class UserNotFoundException : BaseException 
    {
        public UserNotFoundException() : base("PhoneNumber or Password Is Wrong")
        {
            
        }
    }
}
