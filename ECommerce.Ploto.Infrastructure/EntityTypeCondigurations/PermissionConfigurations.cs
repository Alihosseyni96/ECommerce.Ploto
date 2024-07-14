using ECommerce.Ploto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations
{
    internal class PermissionConfigurations : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p=> p.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();



            builder.Property(p => p.PermissionType)
                .IsRequired();

            builder.HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId)
                .IsRequired(false);

        }
    }

}
