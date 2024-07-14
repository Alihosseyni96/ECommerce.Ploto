using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Infrastructure.Context;

namespace ECommerce.Ploto.Infrastructure.Repositories
{
    public  class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(PlotoDbContext db) : base(db)
        {
            
        }
    }
}
