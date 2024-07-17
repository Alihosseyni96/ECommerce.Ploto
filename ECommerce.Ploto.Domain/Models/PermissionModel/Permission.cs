using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.Models.RolePermissionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Domain.Models
{
    public class Permission : BaseEntity<Guid>
    {
        public PermissionType PermissionType { get; protected set; }
        private List<RolePermission> _rolePermissions;

        /// <summary>
        /// backing filed
        /// </summary>
        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions.AsReadOnly();

        /// <summary>
        /// For ORM
        /// </summary>
        private Permission()
        {
            _rolePermissions = new List<RolePermission>();
        }

        /// <summary>
        /// constructor for create in Seed Data 
        /// </summary>
        /// <param name="permissionType"></param>
        private Permission(Guid id,PermissionType permissionType)
        {
            if(_rolePermissions is null)
                _rolePermissions = new List<RolePermission>();

            this.Id = id;
            this.PermissionType = permissionType;
        }
        /// <summary>
        /// Constructor for create Instance 
        /// </summary>
        /// <param name="permissionType"></param>
        private Permission(PermissionType permissionType)
        {
            if (_rolePermissions is null)
                _rolePermissions = new List<RolePermission>();

            this.PermissionType = permissionType;
        }


        /// <summary>
        /// To Create for Seed Data
        /// </summary>
        /// <param name="permissionType"></param>
        /// <returns></returns>
        public static Permission Create(Guid id,PermissionType permissionType) { return new Permission(id,permissionType); }

        /// <summary>
        /// To Ccreate instance
        /// </summary>
        /// <param name="permissionType"></param>
        /// <returns></returns>
        public static Permission Create( PermissionType permissionType) { return new Permission(permissionType); }


        public void AddRolePermission(params (Role role , Permission permission)[] values)
        {
            foreach(var value in values)
            {
                _rolePermissions.Add(RolePermission.Create(value.role, value.permission));
            }
        }

    }
}
