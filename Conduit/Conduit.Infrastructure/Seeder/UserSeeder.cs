
using Conduit.Domain.Constants;
using Conduit.Domain.Entities;
using Conduit.Infrastructure.Identity;
using Conduit.Infrastructure.Persistance;

using Microsoft.AspNetCore.Identity;


namespace Conduit.Infrastructure.Seeders
{
    public class UserSeeder(ConduitDbContext dbContext) : IUserSeeder
    {
        public async Task Seed()
        {

            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }/*
                if (!dbContext.Users.Any())
                {
                    var users = CreateStarterUsers();
                    await dbContext.Users.AddRangeAsync(users);
                }
                */
            }
        }
        public IEnumerable<Role> GetRoles()
        {
            /*
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole(UserRoles.Admin),
                new IdentityRole(UserRoles.User)};
            */
            //List<IdentityRole> roles = [new (UserRoles.Admin), new (UserRoles.User)];
            List<Role> roles = new List<Role>
{
            new Role { Name = UserRoles.Admin },
            new Role { Name = UserRoles.User }
};
            return roles;
        }

        public IEnumerable<User> CreateStarterUsers()
        {
            List<User> users = [new User { UserName = "admin", Email = "admin@admin.com",  }];
            return users;
        }
    }
}
