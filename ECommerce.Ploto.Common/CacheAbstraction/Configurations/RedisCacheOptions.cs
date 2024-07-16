using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.CacheAbstraction.Configurations
{
    public class RedisCacheOptions
    {
        public string Host { get; set; }
        public int Port { get; set; } = 6379;
        public string Password { get; set; }
        public bool? Ssl { get; set; } = false;
        public bool? AbortConnect { get; set; } = false;
        public string ProjectNamePrefix { get; set; }
        public string EnvironmentPrefix { get; set; }
        internal string? Prefix { get => $"{ProjectNamePrefix}-{EnvironmentPrefix}:" ; } 
    }
}
