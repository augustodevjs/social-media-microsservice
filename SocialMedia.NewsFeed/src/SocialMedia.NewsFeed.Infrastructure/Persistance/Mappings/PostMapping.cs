using Microsoft.EntityFrameworkCore;
using SocialMedia.NewsFeed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.PostId);

        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.PublishedAt).IsRequired();

        builder.HasOne<UserNewsfeed>()
            .WithMany(uf => uf.Posts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(x => x.Id);
        builder.Ignore(x => x.IsDeleted);
        builder.Ignore(x => x.CreatedAt);
    }
}
