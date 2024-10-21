﻿using Conduit.Domain.Entities;
using Conduit.Domain.Repositories;
using Conduit.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Infrastructure.Repositories
{
    public class UserRepository (ConduitDbContext dbContext): IUserRepository
    {
        public async Task AddUserAsync(User user) // AnyAsync would be ugly, making it generic would be confusing as not everything has to be updated
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
        public async Task<bool> UsernameExistsAsync(string username)
        {
            var result = await dbContext.Users.AnyAsync(u => u.UserName == username);
            return result;
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            var result = await dbContext.Users.AnyAsync(u => u.Email == email);
            return result;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;
        }
    }
}