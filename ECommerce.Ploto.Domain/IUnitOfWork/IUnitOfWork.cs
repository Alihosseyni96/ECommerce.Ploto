using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.IRepositories.Product;
using ECommerce.Ploto.Domain.IRepositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.UnitOfWork
{
    public interface IUnitOfWork: IBaseUnitOfWork
    {
         IUserRepository UserRepository { get; }   
         IProductRepository ProductRepository { get;  }
    }
}
