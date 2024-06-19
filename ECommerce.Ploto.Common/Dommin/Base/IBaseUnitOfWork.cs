using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public interface IBaseUnitOfWork
    {
        public Task BeginTransactionAsync();
        public Task CommitTransactionAsync();
    }
}
