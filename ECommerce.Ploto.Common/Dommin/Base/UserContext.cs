using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.Dommin.Base
{
    public class UserContext<TKey,TPermissionType>
    {
        public TKey UserId { get; set; }
        public string RoleName { get; set; }
        public TKey RoleId { get; set; }
        public TPermissionType[] Permissions { get; set; }
    }
}
