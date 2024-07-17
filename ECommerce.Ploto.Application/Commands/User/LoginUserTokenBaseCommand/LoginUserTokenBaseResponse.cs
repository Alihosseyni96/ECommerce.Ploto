using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.LoginUserTokenBaseCommand
{
    public record LoginUserTokenBaseResponse
    {
        public string Token { get; init; }
        public LoginUserTokenBaseResponse(string token)
        {
            Token = token;  
        }
    }
}
