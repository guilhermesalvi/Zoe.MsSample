using Microsoft.Extensions.DependencyInjection;
using Zoe.Domain.Extensions;
using Zoe.EventSourcing.Extensions;
using Zoe.EventSourcing.Extensions.BuilderExtensions;
using Zoe.Idempotency.Extensions;
using Zoe.Idempotency.Extensions.BuilderExtensions;

namespace Zoe.MsSample.Api.Configuration
{
    public static class DomainToolsConfig
    {
        public static IServiceCollection AddDomainToolsConfig(this IServiceCollection services)
        {
            services.AddDomainTools()
                    .AddEventSourcing(options =>
                    {
                        options.WithInMemoryDatabase();
                    })
                    .AddIdempotency(options =>
                    {
                        options.WithInMemoryDatabase();
                    });

            return services;
        }
    }
}
