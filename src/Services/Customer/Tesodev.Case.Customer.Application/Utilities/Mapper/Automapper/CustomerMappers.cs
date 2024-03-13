using AutoMapper;
using Tesodev.Case.Customer.Application.Dtos;
using Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate;

namespace Tesodev.Case.Application.Utilities.Mapper.Automapper;

public class CustomerMappers : Profile
{
    public CustomerMappers()
    {
        CreateMap<Tesodev.Case.Customer.Domain.AggregatesModel.CustomerAggregate.Customer, GetCustomerDto>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.GetEmail()))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetName()));
        
        CreateMap<CustomerAddress, GetAddressDto>();
    }
}