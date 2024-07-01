using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<FilteredResult> FindByFilterPaginatedAsync(CancellationToken ct = default , BaseQueryFilter? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter is not null)
            {
                if(filter.SearchTerms?.Count() > 0)
                {
                    foreach (var term in filter.SearchTerms)
                    {
                        query = query.Where(x=> EF.Property<string>(x, term.Key).Contains(term.Value));
                    }
                }

                if(filter.InjectsTo.Count() > 0)
                {
                    foreach(var inject in filter.InjectsTo)
                    {
                        query = query.Include(inject);
                    }
                }

            
                if (!string.IsNullOrEmpty(filter.SortBy))
                {
                    query = filter.SortAscending is true 
                        ? query.OrderByProperty(filter.SortBy)
                        : query.OrderByPropertyDescending(filter.SortBy);
                }

                int skipAmount = (filter.PageNumber - 1) * filter.PageSize;
                query = query.Skip(skipAmount).Take(filter.PageSize);
                int totalCount = await query.CountAsync(ct);
                int totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);
                return new FilteredResult()
                {
                    Data = query.ToListAsync(ct),
                    CurrenPage = filter.PageNumber,
                    TotalPage = totalPages
                };
            }

            return new FilteredResult() { Data = query.ToListAsync(ct)};


        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public async Task<T?> GetbyIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new[] {id}, ct);
            
        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T,bool>> predicate, CancellationToken ct = default, params Expression<Func<T, object>>[]? include)
        {
            IQueryable<T> query =  _dbSet;
            
            if(include != null)
            {
                foreach(var item in include)
                {
                    query = query.Include(item);
                }
            }
                
            return await query.SingleOrDefaultAsync(predicate , ct);
        }


    }
}
