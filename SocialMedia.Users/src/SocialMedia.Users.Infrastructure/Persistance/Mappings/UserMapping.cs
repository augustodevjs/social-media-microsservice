using Microsoft.EntityFrameworkCore;
using SocialMedia.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.Users.Infrastructure.Persistance.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.OwnsOne(u => u.Location, location =>
        {
            location.Property(p => p.City)
                .HasColumnName("City");
            location.Property(p => p.State)
                .HasColumnName("State");
            location.Property(p => p.Country)
                .HasColumnName("Country");
        });

        builder.OwnsOne(u => u.Contact, contact =>
        {
            contact.Property(p => p.Website)
                .HasColumnName("Website");
            contact.Property(p => p.phoneNumber)
                .HasColumnName("PhoneNumber");
        });

        builder.Ignore(p => p.Events);
    }
}
