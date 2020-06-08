using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoe.ApplicationMessage.Extensions;
using Zoe.ApplicationMessage.Extensions.BuilderExtensions;

namespace Zoe.MsSample.Api.Configuration
{
    public static class ApplicationMessageConfig
    {
        public static IServiceCollection AddApplicationMessageConfig(this IServiceCollection services,
                                                                     IConfiguration configuration)
        {
            services.AddApplicationMessage(options =>
            {
                options.LanguageHeaderKey = "Accept-Language";
                options.DefaultLanguageHeaderValue = "pt-br";
                options.LoadMessagesFromSettings(configuration);
            });

            return services;
        }
    }
}
