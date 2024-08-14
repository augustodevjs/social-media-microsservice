using SocialMedia.Users.Domain.Entities;

namespace SocialMedia.Users.Domain.Contracts.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task<User> GetByIdAsync(Guid id);
}
