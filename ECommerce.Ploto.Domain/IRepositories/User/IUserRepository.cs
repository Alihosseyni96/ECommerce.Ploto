using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.IRepositories.User
{
    public interface IUserRepository : IGenericRepository<Domain.Models.User.User>
    {
    }
}
