using AutoMapper;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer;
using Zoe.MsSample.Application.ViewModels;

namespace Zoe.MsSample.Application.AutoMapper
{
    public class CommandToViewModelMappingProfile : Profile
    {
        public CommandToViewModelMappingProfile()
        {
            CreateMap<RegisterCustomerCommand, RegisterCustomerViewModel>();
            CreateMap<RemoveCustomerCommand, RemoveCustomerViewModel>();
            CreateMap<UpdateCustomerCommand, UpdateCustomerViewModel>();
        }
    }
}
