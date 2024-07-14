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

    }
}
