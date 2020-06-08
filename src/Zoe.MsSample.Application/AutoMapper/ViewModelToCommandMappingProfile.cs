using AutoMapper;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RegisterCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.RemoveCustomer;
using Zoe.MsSample.Application.UseCases.CustomerAggregate.UpdateCustomer;
using Zoe.MsSample.Application.ViewModels;

namespace Zoe.MsSample.Application.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<RegisterCustomerViewModel, RegisterCustomerCommand>()
                .ConstructUsing(x => new RegisterCustomerCommand(x.FullName, x.Alias, x.Email, x.BirthDate));

            CreateMap<RemoveCustomerViewModel, RemoveCustomerCommand>()
                .ConstructUsing(x => new RemoveCustomerCommand(x.Id));

            CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(x => new UpdateCustomerCommand(x.Id, x.FullName, x.Alias, x.Email, x.BirthDate));
        }
    }
}
