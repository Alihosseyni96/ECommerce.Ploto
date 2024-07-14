using ECommerce.Ploto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();



        builder.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(r => r.RolePermissions)
            .WithOne(rp => rp.Role)
            .HasForeignKey(rp => rp.RoleId)
            .IsRequired();

        builder.HasMany(r=> r.Users)
            .WithOne(u=> u.Role)
            .HasForeignKey(u=> u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        

    }
}
