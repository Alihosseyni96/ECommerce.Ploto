using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Infrastructure.Context;

namespace ECommerce.Ploto.Infrastructure.Repositories
{
    public class RoleRepositopry : GenericRepository<Role> , IRoleRepository 
    {
        public RoleRepositopry(PlotoDbContext db):base(db)
        {
            
        }
    }
}
