using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Zoe.MsSample.Application.PipelineBehavior;

namespace Zoe.MsSample.Api.Configuration
{
    public static class FluentValidationConfig
    {
        public static IServiceCollection AddFailFastValidationPipelineConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidationRequestBehavior<,>));

            const string applicationAssemblyName = "Zoe.MsSample.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            return services;
        }
    }
}
