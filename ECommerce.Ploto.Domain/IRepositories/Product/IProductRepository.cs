using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.IRepositories.Product
{
    public interface IProductRepository : IGenericRepository<Domain.Models.Product.Product>
    {
    }
}
