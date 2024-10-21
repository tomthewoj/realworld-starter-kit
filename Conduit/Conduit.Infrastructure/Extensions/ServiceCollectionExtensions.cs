using Conduit.Domain.Entities;
using Conduit.Domain.Repositories;
using Conduit.Infrastructure.Identity;
using Conduit.Infrastructure.Persistance;
using Conduit.Infrastructure.Repositories;
using Conduit.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Conduit.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ConduitDbContext>(options => 
            options.UseSqlServer(connectionString));

            services.AddScoped<IUserSeeder, UserSeeder>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ConduitDbContext>()
            .AddDefaultTokenProviders();
        }

    }
}
