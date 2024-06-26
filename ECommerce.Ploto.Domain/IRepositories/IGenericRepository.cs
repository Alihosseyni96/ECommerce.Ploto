using ECommerce.Ploto.Common.Dommin.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.IRepositories
{
    public interface IGenericRepository<T> : IBaseGenericRepository<T,Guid> where T : class
    {
    }
}
