using ECommerce.Ploto.Domain.Models.Image;
using ECommerce.Ploto.Domain.Models.Product;
using ECommerce.Ploto.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations
{
    internal class Imageentityconfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            
            builder.HasKey(x => x.Id);

            builder.HasOne(i => i.User)
                .WithOne(u => u.Avatar)
                .HasForeignKey<Image>(i => i.UserId);

            builder.HasOne(i => i.Product)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.ProductId);

        }
    }
}
