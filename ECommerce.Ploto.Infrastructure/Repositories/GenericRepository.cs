using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.Domain.IRepositories;
using ECommerce.Ploto.Domain.Models.User;
using ECommerce.Ploto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

            if (predicate != null)
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

        public async Task<FilteredResult<T>> FindByFilterPaginatedAsync(CancellationToken ct = default, BaseQueryFilter? filter = null, params string[]? includeThenIncludes)
        {
            IQueryable<T> query = _dbSet;

            if (filter is not null)
            {
                if (filter?.Keyword is not null)
                {
                    var properties = typeof(T)
                        .GetProperties()
                    .Where(p => p.PropertyType == typeof(string) || p.PropertyType.IsSubclassOf(typeof(BaseValueObject)))
                    .ToList();



                    if (properties.Count() > 0)
                    {
                        var parameter = Expression.Parameter(typeof(T), "x");
                        Expression? searchExpression = null;

                        foreach (var property in properties)
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                var propertyAccess = Expression.Property(parameter, property);
                                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                                if (containsMethod != null)
                                {
                                    for (int i = 0; i < filter.Keyword.Length; i++)
                                    {
                                        var keyword = Expression.Constant(filter.Keyword[i], typeof(string));
                                        var containsExpression = Expression.Call(propertyAccess, containsMethod, keyword);

                                        searchExpression = searchExpression == null
                                            ? (Expression)containsExpression
                                            : Expression.OrElse(searchExpression, containsExpression);

                                    }
                                }
                            }
                            else if (property.PropertyType.IsClass && typeof(BaseValueObject).IsAssignableFrom(property.PropertyType))
                            {
                                var valueObjectProperties = property.PropertyType.GetProperties()
                                                                                .Where(p => p.PropertyType == typeof(string))
                                                                                .ToList();

                                foreach (var valueObjectProperty in valueObjectProperties)
                                {
                                    var propertyAccess = Expression.Property(Expression.Property(parameter, property), valueObjectProperty);
                                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                                    if (containsMethod != null)
                                    {
                                        for (int i = 0; i < filter.Keyword.Length; i++)
                                        {
                                            var keyword = Expression.Constant(filter.Keyword[i], typeof(string));
                                            var containsExpression = Expression.Call(propertyAccess, containsMethod, keyword);

                                            searchExpression = searchExpression == null
                                                ? (Expression)containsExpression
                                                : Expression.OrElse(searchExpression, containsExpression);

                                        }
                                    }
                                }
                            }
                        }
                        if (searchExpression != null)
                        {
                            var lambda = Expression.Lambda<Func<T, bool>>(searchExpression, parameter);
                            query = query.Where(lambda);
                        }
                    }





                }

                if (filter.From.HasValue || filter.To.HasValue)
                {
                    var dateProperties = typeof(T)
                        .GetProperties()
                        .Where(x => x.PropertyType == typeof(DateTime))
                        .ToList();

                    if (dateProperties.Any())
                    {
                        var parameter = Expression.Parameter(typeof(T), "x");
                        Expression? dateExpression = null;

                        foreach (var property in dateProperties)
                        {
                            var propertyAccess = Expression.Property(parameter, property);

                            if (filter.From.HasValue)
                            {
                                var fromExpression = Expression.GreaterThanOrEqual(propertyAccess, Expression.Constant(filter.From.Value));
                                dateExpression = dateExpression == null ? fromExpression : Expression.AndAlso(dateExpression, fromExpression);
                            }

                            if (filter.To.HasValue)
                            {
                                var toExpression = Expression.LessThanOrEqual(propertyAccess, Expression.Constant(filter.To.Value));
                                dateExpression = dateExpression == null ? toExpression : Expression.AndAlso(dateExpression, toExpression);
                            }
                        }
                        if (dateExpression != null)
                        {
                            var lambda = Expression.Lambda<Func<T, bool>>(dateExpression, parameter);
                            query = query.Where(lambda);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(filter.SortBy))
                {
                    query = filter.SortAscending is true
                        ? query.OrderByProperty(filter.SortBy)
                        : query.OrderByPropertyDescending(filter.SortBy);
                }


                if (includeThenIncludes is not null)
                {
                    foreach (var includeThenInclude in includeThenIncludes)
                    {

                        query = query.Include(includeThenInclude);
                    }
                }


                int skipAmount = (filter.PageNumber - 1) * filter.PageSize;
                query = query.Skip(skipAmount).Take(filter.PageSize);
                int totalCount = await query.CountAsync(ct);
                int totalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize);
                return new FilteredResult<T>()
                {
                    Data = await query.ToListAsync(ct),
                    CurrenPage = filter.PageNumber,
                    TotalPage = totalPages
                };

            }



            return new FilteredResult<T>() { Data = await query.ToListAsync(ct) };


        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public async Task<T?> GetbyIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(new[] { id }, ct);

        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default, params Expression<Func<T, object>>[]? include )
        {
            IQueryable<T> query = _dbSet;

            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            return await query.SingleOrDefaultAsync(predicate, ct);
        }

        public async Task<T> SingleOrDdfaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default, params string[]? includeThenIncludes )
        {
            IQueryable<T> query = _dbSet;

            if(includeThenIncludes is not null)
            {
                foreach (var includeThenInclude in includeThenIncludes)
                {

                    query = query.Include(includeThenInclude);
                }
            }
            return await query.SingleOrDefaultAsync(predicate, ct);


        }



    }
}
