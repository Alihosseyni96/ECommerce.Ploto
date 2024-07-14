using ECommerce.Ploto.Common.Dommin.Base;

namespace ECommerce.Ploto.Domain.Models.RolePermissionModel
{
    public class RolePermission : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid RoleId { get; protected set; }
        public Guid PermissionId { get; protected set; }

        public Role Role { get; protected set; }
        public Permission Permission { get; protected set; }

        //To ORM
        private RolePermission() { }

        private RolePermission(Role role, Permission permission)
        {
            RoleId = role.Id;
            PermissionId = permission.Id;
        }

        private RolePermission(Guid id, Role role, Permission permission)
        {
            Id = id;
            //Role = role;
            //Permission = permission;
            RoleId = role.Id;
            PermissionId = permission.Id;
        }


        /// <summary>
        /// To Create instance
        /// </summary>
        /// <param name="role"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static RolePermission Create(Role role, Permission permission)
        {
            return new RolePermission(role, permission);
        }

        public static RolePermission Create(Guid id, Role role, Permission permission)
        {
            return new RolePermission(id, role, permission);
        }



    }
}
