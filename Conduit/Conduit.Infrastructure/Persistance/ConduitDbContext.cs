﻿using Conduit.Domain.Entities;
using Conduit.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Conduit.Infrastructure.Persistance
{
    //public class ConduitDbContext(DbContextOptions<ConduitDbContext> options) : IdentityDbContext<User, Role, Guid>(options)
    public class ConduitDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ConduitDbContext(DbContextOptions<ConduitDbContext> options)
            : base(options)
        {
        }
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


            modelBuilder.Entity<Comment>().HasOne(u => u.Author).WithMany(u => u.Comments).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Favorite>().HasOne(u => u.User).WithMany(f => f.Favorites).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}