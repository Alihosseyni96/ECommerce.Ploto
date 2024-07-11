﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Queries.User.UserLoginQuery
{
    public record UserLoginQuery(string pboneNumber , string password) : IRequest<UserLoginResponse>;
}
