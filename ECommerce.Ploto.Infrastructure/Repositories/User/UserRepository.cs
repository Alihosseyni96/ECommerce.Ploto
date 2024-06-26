using ECommerce.Ploto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.Repositories.User
{
    public  class UserRepository : GenericRepository<Domain.Models.User.User>
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            
        }
    }
}
