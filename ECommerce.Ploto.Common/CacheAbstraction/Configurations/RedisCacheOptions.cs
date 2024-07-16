using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.CacheAbstraction.Configurations
{
    public class RedisCacheOptions
    {
        public string ConnectionString { get; set; }
        public string ProjectNamePrefix { get; set; }
        public string EnvironmentPrefix { get; set; }
        internal string? Prefix { get => $"{ProjectNamePrefix}-{EnvironmentPrefix}-" ; } 
    }
}
