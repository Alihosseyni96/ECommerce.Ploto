using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity); 
        }


        public async Task<IEnumerable<T>> FindAsync(CancellationToken cancellationToken = default, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbSet;

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (include != null)
            {
                foreach (var includeProperty in include)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public async Task<T?> GetbyIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new[] {id}, ct);
        }
    }
}
