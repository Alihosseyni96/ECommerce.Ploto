﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public interface IBaseGenericRepository<T,TKey> where T : class
    {
        Task<T> GetbyIdAsync(TKey id , CancellationToken ct = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct  = default);
        Task AddAsync(T entity, CancellationToken ct = default);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> FindAsync(
            CancellationToken cancellationToken = default,
            Expression<Func<T, bool>>? predicate = null ,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] include );

    }
}