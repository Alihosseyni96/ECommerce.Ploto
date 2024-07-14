using ECommerce.Ploto.Domain.Models.RolePermissionModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations
{
    internal class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp=> rp.Id);

            builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();


            builder.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .IsRequired();

            builder.HasOne(rp=> rp.Permission)
                .WithMany(p=> p.RolePermissions)
                .HasForeignKey(rp=> rp.PermissionId)
                .IsRequired();
        }
    }
}
