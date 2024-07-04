using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public record BaseQueryFilter : PagingBaseParams
    {
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
        public string[]? Keyword { get; set; }
        public string? SortBy { get; set; }
        public bool? SortAscending { get; set; } = false;
    }
}
