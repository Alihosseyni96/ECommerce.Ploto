using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Infrastructure.Context;

namespace ECommerce.Ploto.Infrastructure.Repositories
{
    public class RoleRepositopry : GenericRepository<Role> , IRoleRepository 
    {
        public RoleRepositopry(ApplicationDbContext db):base(db)
        {
            
        }
    }
}
