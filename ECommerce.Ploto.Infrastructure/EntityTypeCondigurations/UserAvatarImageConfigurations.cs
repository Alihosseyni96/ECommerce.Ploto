using ECommerce.Ploto.Domain.Models.Image;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Ploto.Infrastructure.EntityTypeCondigurations;

internal class UserAvatarImageConfigurations : IEntityTypeConfiguration<UserAvaterImage>
{
    public void Configure(EntityTypeBuilder<UserAvaterImage> builder)
    {

        builder.HasOne(x => x.User)
            .WithOne(x => x.Avatar)
            .HasForeignKey<UserAvaterImage>(x => x.UserId);
    }
}
