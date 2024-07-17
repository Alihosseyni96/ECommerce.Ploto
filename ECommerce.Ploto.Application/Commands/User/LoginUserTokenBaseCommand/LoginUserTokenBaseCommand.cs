using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.LoginUserTokenBaseCommand
{
    public record LoginUserTokenBaseCommand(string phoneNumber , string password) : IRequest<LoginUserTokenBaseResponse>;
    
    
}
