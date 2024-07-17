using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.RolePermissionModel;

namespace ECommerce.Ploto.Domain.Models
{
    public class Role : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        private List<User> _users;
        private List<RolePermission> _rolePermissions;

        /// <summary>
        /// backing filed
        /// </summary>
        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions.AsReadOnly();

        public IReadOnlyCollection<User> Users => _users.AsReadOnly();
        /// <summary>
        /// constructor for ORM
        /// </summary>
        private Role()
        {
            _rolePermissions = new List<RolePermission>();
        }

        /// <summary>
        /// constructor for create instanc with id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private Role(Guid id, string name)
        {
            Name = name;
            this.Id = id;
            _rolePermissions = new List<RolePermission>();

        }

        /// <summary>
        /// Constructore to Create instance
        /// </summary>
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
        public static Role Create(Guid id, string name)
        {
            return new Role(id, name);
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
