using Microsoft.Extensions.DependencyInjection;

namespace Zoe.MsSample.Api.Configuration
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfig(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}
