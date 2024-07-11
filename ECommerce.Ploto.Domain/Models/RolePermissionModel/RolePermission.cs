using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models.RolePermissionModel
{
    public class RolePermission : BaseEntity<Guid> , IAggregateRoot
    {
        public Guid RoleId { get; protected set; }
        public Guid PermissionId { get; protected set; }

        public Role Role { get; protected set; }
        public Permission Permission { get; protected set; }

        //To ORM
        private RolePermission() { }

        private RolePermission(Role role , Permission permission)
        {
            Role = role;
            Permission = permission;
        }

        public static RolePermission Create(Role role , Permission permission)
        {
            return new RolePermission(role , permission);
        }

    }
}
