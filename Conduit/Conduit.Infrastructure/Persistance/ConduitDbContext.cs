using Conduit.Application.Entities;
using Conduit.Domain.Constants;
using Conduit.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Conduit.Infrastructure.Persistance
{
    public class ConduitDbContext(DbContextOptions<ConduitDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
    {
       // public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<FollowUser> FollowUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowUser>()
           .HasOne(f => f.FollowedUser)
           .WithMany(f => f.FollowedUsers)
           .HasForeignKey(f => f.FollowedUserId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FollowUser>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
