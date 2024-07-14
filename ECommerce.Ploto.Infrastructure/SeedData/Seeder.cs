using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Domain.Models.RolePermissionModel;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECommerce.Ploto.Infrastructure
{
    internal class Seeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {

            #region Permissions
            var permission1 = Permission.Create(Guid.NewGuid(), PermissionType.UserPanelAccess);
            var permission2 = Permission.Create(Guid.NewGuid(), PermissionType.AdminPanelAccess);

            modelBuilder.Entity<Permission>()
                .HasData(permission1, permission2);

            #endregion

            #region Role
            var role1 = Role.Create(Guid.NewGuid(), "Admin");
            var role2 = Role.Create(Guid.NewGuid(), "User");

            modelBuilder.Entity<Role>()
                .HasData(role1, role2);

            #endregion

            #region RolePermission
            var rolePermission1 = RolePermission.Create(Guid.NewGuid(), role1, permission1);
            var rolePermission2 = RolePermission.Create(Guid.NewGuid(), role1, permission2);
            var rolePermission3 = RolePermission.Create(Guid.NewGuid(), role2, permission1);

            modelBuilder.Entity<RolePermission>()
                .HasData(rolePermission1, rolePermission2, rolePermission3);

            #endregion

            #region User - how to seed entity which have value Objetcs
            var adminuser = User.Create(Guid.NewGuid(), Name.Create("pourya", "hosseyni"), "09386562888", "123456", HomeNumber.Create("123456799", "021"), Address.Create("tehran", "resalat", 54));
            adminuser.AddRoleInSeed(role1);

            modelBuilder.Entity<User>(builder =>
            {

                builder.OwnsOne(u => u.Address)
                .HasData(new { UserId = adminuser.Id, City = "tehran", Avenue = "resalat", HouseNO = 54 });

                builder.OwnsOne(u => u.Name)
                .HasData(new { UserId = adminuser.Id, FirtsName = adminuser.Name.FirtsName, LastName = adminuser.Name.LastName });

                builder.OwnsOne(u=> u.HomeNumber)
                .HasData(new { UserId = adminuser.Id, Number = adminuser.HomeNumber.Number, CityCode= adminuser.HomeNumber.CityCode });

                builder.HasData(new {Id = adminuser.Id , PhoneNumber = adminuser.PhoneNumber, Password = "123456", RoleId = adminuser.RoleId });
            });

            #endregion


        }

    }
}
