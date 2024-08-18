using Microsoft.EntityFrameworkCore;
using SocialMedia.NewsFeed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.PublishedAt).IsRequired();
    }
}
