﻿using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using ECommerce.Ploto.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;

namespace ECommerce.Ploto.Infrastructure.UnitOfWork
{
    public class UnitOfWork :   BaseUnitOfWork , IPlotoUnitOfWork
    {
        private readonly PlotoDbContext _context;
        private IDbContextTransaction _currentTransaction;
        private TransactionScope _transactionScope;




        public IUserRepository UserRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IPermissionRepository PermissionRepository { get; set; }
        
        public UnitOfWork(PlotoDbContext db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));

            if (_context == null) _context = db;

            if (UserRepository == null) UserRepository = new UserRepository(db);

            if (ProductRepository == null) ProductRepository = new ProductRepository(db);

            if(RoleRepository == null) RoleRepository = new RoleRepositopry(db);    

            if(PermissionRepository == null) PermissionRepository = new PermissionRepository(db);
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


        public async Task SaveChangeAsync(CancellationToken ct = default)
        {
            await _context.SaveChangesAsync(ct);
        }
    }
}
