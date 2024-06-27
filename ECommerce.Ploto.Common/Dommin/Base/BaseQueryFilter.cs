using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public record BaseQueryFilter : PagingBaseParams
    {
        public Dictionary<string, string>? SearchTerms { get; set; }
        public string[]? InjectsTo { get; set; }
        public string? SortBy { get; set; }
        public bool? SortAscending { get; set; } = false;
        public BaseQueryFilter()
        {
            SearchTerms = new Dictionary<string, string>(); 
        }
    }
}
