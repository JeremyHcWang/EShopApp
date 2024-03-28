using AutoMapper;
using OrderAPI_ApplicationCore.Entities;
using OrderAPI_ApplicationCore.Models.Response;

namespace OrderAPI;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderResDto>();
    }
}