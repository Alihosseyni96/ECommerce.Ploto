using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.RolePermissionModel;

namespace ECommerce.Ploto.Domain.Models
{
    public class Role : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        private List<RolePermission> _rolePermissions;

        /// <summary>
        /// backing filed
        /// </summary>
        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions.AsReadOnly();


        /// <summary>
        /// constructor for ORM
        /// </summary>
        private Role() { }

        /// <summary>
        /// constructor for create object in local File
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private Role(string name)
        {
            Name = name;
            _rolePermissions = new List<RolePermission>();

        }



        /// <summary>
        /// to create role in database with seed
        /// </summary>
        /// <returns></returns>
        public static Role Create(string name)
        {
            return new Role(name);
        }
        /// <summary>
        /// Add Role Permissions
        /// </summary>
        /// <param name="values"></param>
        public void AddRolePermission(params (Role role, Permission permission)[] values)
        {
            foreach (var value in values)
            {
                _rolePermissions.Add(RolePermission.Create(value.role, value.permission));
            }
        }



    }
}
