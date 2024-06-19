using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public interface IBaseRepository<in T> where T : class
    {
        public Task GetAsync(Guid id);
        public Task Insert(T t);
    }
}
