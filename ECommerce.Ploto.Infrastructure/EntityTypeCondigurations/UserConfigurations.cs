using ECommerce.Ploto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.OwnsOne(u => u.Name, nameBuilder =>
            {
                nameBuilder.Property(x => x.FirtsName)
                .HasMaxLength(50)
                .IsRequired();
                //.HasColumnName("first_name");
            });

            builder.OwnsOne(u => u.HomeNumber, homeNumberBuilder =>
            {
                homeNumberBuilder.Property(n=> n.Number)
                .HasMaxLength (50)
                //.HasColumnName("home_number")
                .IsRequired();

                homeNumberBuilder.Property(n=> n.CityCode)
                .HasMaxLength(3)
                //.HasColumnName("city_code")
                .IsRequired();  
            });

            builder.OwnsOne(u => u.Address, addressBuilder =>
            {
                addressBuilder.Property(ad=> ad.City)
                .HasMaxLength(20)
                //.HasColumnName("city")
                .IsRequired();

                addressBuilder.Property(ad=> ad.Avenue)
                .HasMaxLength(50)
                //.HasColumnName("avenue")
                .IsRequired ();

                addressBuilder.Property(ad=> ad.HouseNO)
                //.HasColumnName("house_no")
                .IsRequired();
            });

            builder.HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CartId);

            builder.HasOne(u => u.Avatar)
                .WithOne(i => i.User)
                .HasForeignKey<User>(u => u.AvatarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

        }
    }
}
