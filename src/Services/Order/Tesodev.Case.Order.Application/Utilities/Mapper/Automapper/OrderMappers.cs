using AutoMapper;
using Tesodev.Case.Order.Application.Dtos;
using Tesodev.Case.Order.Domain.AggregatesModel.OrderAggregate;

namespace Trendyol.Case.Application.Utilities.Mapper.Automapper;

public class OrderMappers : Profile
{
    public OrderMappers()
    {
        CreateMap<Order, GetOrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.GetQuantity()))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.GetPrice()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.GetStatus()));

        CreateMap<OrderAddress, GetAddressDto>();
        CreateMap<OrderProduct, GetProductDto>();
    }
}