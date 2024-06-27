using ECommerce.Ploto.Common.Dommin.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public record GetUsersQuery : BaseQueryFilter , IRequest<FilteredResult> 
    {
    }
}
