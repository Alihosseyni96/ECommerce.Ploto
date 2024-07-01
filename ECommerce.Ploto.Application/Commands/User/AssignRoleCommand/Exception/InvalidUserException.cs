using ECommerce.Ploto.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.AssignRoleCommand.Exception
{
    internal class InvalidUserException : BaseException
    {
        public InvalidUserException() : base("Invalid User Id")
        {
            
        }
    }
}
