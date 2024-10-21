using Conduit.Domain.Entities;
using Conduit.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;


namespace Conduit.Infrastructure.Seeders
{
    public interface IUserSeeder
    {
        Task Seed();
        IEnumerable<Role> GetRoles();
        IEnumerable<User> CreateStarterUsers();
    }
}
