using AutoMapper;
using Zoe.MsSample.Application.ViewModels;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
