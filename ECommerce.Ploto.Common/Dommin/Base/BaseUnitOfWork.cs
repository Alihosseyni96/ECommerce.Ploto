using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        private TransactionScope _transactionScope;

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
    }
}
