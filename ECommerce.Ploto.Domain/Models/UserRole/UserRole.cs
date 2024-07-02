using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.Role;
using ECommerce.Ploto.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models.UserRole
{
    public class UserRole : BaseEntity
    {
        public Guid UserId { get;private set; }
        public Guid RoleId { get; private set; }

        public User.User User { get; private set; }
        public Role.Role Role { get; private set; }

        // Private constructor for Entity Framework
        private UserRole() { }

        // Constructor to create UserRole in services
        private UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public static UserRole Create(Guid userId, Guid roleId)
        {
            return new UserRole(userId, roleId);
        }
    }
}
