using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.IRepositories;

namespace ECommerce.Ploto.Domain.UnitOfWork
{
    public interface IUnitOfWork: IBaseUnitOfWork
    {
         IUserRepository UserRepository { get; }   
         IProductRepository ProductRepository { get;  }
         IRoleRepository RoleRepository { get; }
    }
}
