using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public interface IBaseUnitOfWork
    {
        /// <summary>
        /// Open TransactionScope
        /// </summary>
        public void BeginTransactionScope();

        /// <summary>
        /// Complete Oped TransactionScope 
        /// </summary>
        public void CompleteTransactionScope();

        /// <summary>
        /// Begin Transaction
        /// </summary>
        /// <returns></returns>
        public Task BeginTransactionAsync(CancellationToken ct  = default);
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
    }
}
