using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Infrastructure.Context;

namespace ECommerce.Ploto.Infrastructure.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(PlotoDbContext db) :base (db)
        {
            
        }
    }
}
