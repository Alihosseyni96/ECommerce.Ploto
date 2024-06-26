using ECommerce.Ploto.Domain.IRepositories.Product;
using ECommerce.Ploto.Domain.IRepositories.User;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using ECommerce.Ploto.Infrastructure.Repositories.Product;
using ECommerce.Ploto.Infrastructure.Repositories.User;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ECommerce.Ploto.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _currentTransaction;
        private TransactionScope _transactionScope;




        public IUserRepository UserRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));

            if (_context == null) _context = db;

            if (UserRepository == null) UserRepository = new UserRepository(db);

            if (ProductRepository == null) ProductRepository = new ProductRepository(db);
        }


        public async Task BeginTransactionAsync(CancellationToken ct = default)
        {
            if (_currentTransaction is null)
                _currentTransaction = await _context.Database.BeginTransactionAsync(ct);

        }

        public async Task CommitTransactionAsync(CancellationToken ct = default)
        {
            try
            {
                await _currentTransaction.CommitAsync(ct);
            }
            catch (Exception e)
            {
                await _currentTransaction.RollbackAsync(ct);
                throw e;
            }
            finally
            {
                if (_currentTransaction is not null)
                    _currentTransaction.Dispose();

                _currentTransaction = null;
            }

        }

        public void BeginTransactionScope()
        {
            _transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }


        public void CompleteTransactionScope()
        {
            try
            {
                _transactionScope.Complete();
            }
            finally
            {
                _transactionScope?.Dispose();
                _transactionScope = null;
            }

        }


        public async Task SaveChangeAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }
    }
}
