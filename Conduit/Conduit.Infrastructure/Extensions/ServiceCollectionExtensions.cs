using Conduit.Application.Entities;
using Conduit.Domain.Repositories;
using Conduit.Infrastructure.Persistance;
using Conduit.Infrastructure.Repositories;
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

            services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<ConduitDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
