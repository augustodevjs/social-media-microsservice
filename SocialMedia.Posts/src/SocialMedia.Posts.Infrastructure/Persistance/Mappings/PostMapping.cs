using Microsoft.EntityFrameworkCore;
using SocialMedia.Posts.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.Posts.Infrastructure.Persistance.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Content)
               .IsRequired()
               .HasMaxLength(500);

        builder.OwnsOne(p => p.User, user =>
        {
            user.Property(u => u.Id)
                .IsRequired()
                .HasColumnName("UserId");

            user.Property(u => u.DisplayName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("UserDisplayName");
        });

        builder.Ignore(p => p.Events);
    }
}
