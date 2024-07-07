using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public class FilteredResult<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int? CurrenPage { get; set; }
        public int? TotalPage { get; set; }
    }
}
