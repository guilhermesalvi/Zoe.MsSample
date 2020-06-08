using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Zoe.Domain.Results;
using Zoe.MsSample.Application.Services;
using Zoe.MsSample.Application.Services.Abstractions;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;
using Zoe.MsSample.Infrastructure.Data.Repositories.CustomerAggregate;

namespace Zoe.MsSample.Api.Configuration
{
    public static class DependenciesConfig
    {
        public static IServiceCollection AddDependenciesConfig(this IServiceCollection services)
        {
            // Application - Services
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Application - RegisterCustomer
            services.AddScoped<IRequestHandler<RegisterCustomerCommand, CommandResult>, RegisterCustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, CommandResult>, RemoveCustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, CommandResult>, UpdateCustomerCommandHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerRegisteredEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerRemovedEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerUpdatedEventHandler>();

            // Domain - CustomerAggregate
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
