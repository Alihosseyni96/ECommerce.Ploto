using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Domain.Models.RolePermissionModel;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ECommerce.Ploto.Infrastructure
{
    internal class Seeder 
    {

        public static void Seed(ModelBuilder modelBuilder)
        {

            #region Permissions
            var permission1 = Permission.Create(PermissionType.UserPanelAccess);
            var permission2 = Permission.Create(PermissionType.AdminPanelAccess);

            modelBuilder.Entity<Permission>()
                .HasData(permission1, permission2);

            #endregion

            #region Role
            var role1 = Role.Create("Admin");
            var role2 = Role.Create("User");

            modelBuilder.Entity<Role>()
                .HasData(role1, role2);

            #endregion

            #region RolePermission
            var rolePermission1 = RolePermission.Create(role1, permission1);
            var rolePermission2 = RolePermission.Create(role1, permission2);
            var rolePermission3 = RolePermission.Create(role2, permission1);

            modelBuilder.Entity<RolePermission>()
                .HasData(rolePermission1, rolePermission2, rolePermission3);

            #endregion

        }

    }
}
