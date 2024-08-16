using Microsoft.EntityFrameworkCore;
using SocialMedia.Posts.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.Posts.Infrastructure.Persistance.Mappings;

public class PostMapping : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
    }
}