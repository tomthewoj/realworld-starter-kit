using Conduit.Application.Entities;

namespace Conduit.Domain.Repositories;

public interface IUserRepository
{
    Task<Guid> AddUserAsync(User user);
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailExistsAsync(string email);
}
