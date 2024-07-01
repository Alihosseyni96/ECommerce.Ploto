using ECommerce.Ploto.Domain.IRepositories.Role;
using ECommerce.Ploto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.Repositories.Role
{
    public class RoleRepositopry : GenericRepository<Domain.Models.Role.Role> , IRoleRepository 
    {
        public RoleRepositopry(ApplicationDbContext db):base(db)
        {
            
        }
    }
}
