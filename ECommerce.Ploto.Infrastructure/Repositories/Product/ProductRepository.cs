using ECommerce.Ploto.Domain.Models.Product;
using ECommerce.Ploto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.Repositories.Product
{
    public class ProductRepository : GenericRepository<Domain.Models.Product.Product>
    {
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
        }
    }
}
