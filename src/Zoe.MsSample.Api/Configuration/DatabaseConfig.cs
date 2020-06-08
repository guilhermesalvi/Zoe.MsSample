using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zoe.Data.UoW;
using Zoe.MsSample.Infrastructure.Data.Context;
using Zoe.MsSample.Infrastructure.Data.UoW;

namespace Zoe.MsSample.Api.Configuration
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
        {
            services.AddDbContext<MsSampleDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "MsSampleDatabase");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
