
using Conduit.Domain.Entities;

namespace Conduit.Domain.Repositories;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailExistsAsync(string email);
    Task<IEnumerable<User>> GetUsersAsync();
}
