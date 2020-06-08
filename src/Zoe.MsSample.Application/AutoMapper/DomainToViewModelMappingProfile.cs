using AutoMapper;
using Zoe.MsSample.Application.ViewModels;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name.FullName))
                .ForMember(dest => dest.Alias, opt => opt.MapFrom(src => src.Name.Alias))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Address))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Value));
        }
    }
}
