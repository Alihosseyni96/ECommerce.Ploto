using ECommerce.Ploto.Domain.Models.Product;
using ECommerce.Ploto.Domain.Models.Product.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(m => m.Amount);
                priceBuilder.Property(m => m.Currency)
                .HasMaxLength(10)
                .IsRequired();
            });

            builder.OwnsOne(p => p.Dimensions, dimensionsBuilder =>
            {
                dimensionsBuilder.Property(d => d.Length)
                .HasColumnName("dimension_length")
                .IsRequired();

                dimensionsBuilder.Property(d => d.Width)
                .HasColumnName("dimension_width")
                .IsRequired();

                dimensionsBuilder.Property(d => d.Height)
                .HasColumnName("dimension_height")
                .IsRequired();
            });

            builder.HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product);

            builder.HasMany(p=> p.Images)
                .WithOne(i=> i.Product)
                .OnDelete(DeleteBehavior.Restrict);
                

        }
    }
}
