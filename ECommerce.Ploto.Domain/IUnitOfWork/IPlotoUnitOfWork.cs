using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.IRepositories;

namespace ECommerce.Ploto.Domain.UnitOfWork
{
    public interface IPlotoUnitOfWork : IBaseUnitOfWork
    {

        /// <summary>
        /// Begin Transaction
        /// </summary>
        /// <returns></returns>
        public Task BeginTransactionAsync(CancellationToken ct = default);
        /// <summary>
        /// Commit Transaction
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task CommitTransactionAsync(CancellationToken ct = default);

        /// <summary>
        /// Apply Save Change On DataBase
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task SaveChangeAsync(CancellationToken ct = default);

        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }


    }
}
