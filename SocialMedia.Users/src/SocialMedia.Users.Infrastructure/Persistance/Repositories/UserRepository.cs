using SocialMedia.Users.Domain.Entities;
using SocialMedia.Users.Domain.Contracts.Repositories;
using SocialMedia.Users.Infrastructure.Persistance.Context;
using SocialMedia.Users.Infrastructure.Persistance.Abstractions;

namespace SocialMedia.Users.Infrastructure.Persistance.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
