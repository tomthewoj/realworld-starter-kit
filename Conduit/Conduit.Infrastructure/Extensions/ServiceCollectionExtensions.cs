using Conduit.Application.Entities;
using Conduit.Domain.Constants;
using Conduit.Domain.Repositories;
using Conduit.Infrastructure.Identity;
using Conduit.Infrastructure.Persistance;
using Conduit.Infrastructure.Repositories;
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

            /*
            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ConduitDbContext>();
            */
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ConduitDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
