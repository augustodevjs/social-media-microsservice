using Microsoft.EntityFrameworkCore;
using SocialMedia.NewsFeed.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Mappings;

public class UserNewsfeedMapping : IEntityTypeConfiguration<UserNewsfeed>
{
    public void Configure(EntityTypeBuilder<UserNewsfeed> builder)
    {
        builder.HasKey(uf => uf.UserId);
        builder.Property(uf => uf.UserId).IsRequired();
        builder.Ignore(uf => uf.Events);
    }
}
