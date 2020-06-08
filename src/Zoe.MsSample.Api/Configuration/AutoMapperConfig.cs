using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Zoe.MsSample.Application.AutoMapper;

namespace Zoe.MsSample.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandToViewModelMappingProfile), typeof(ViewModelToCommandMappingProfile));
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            return services;
        }
    }
}
