using AutoMapper;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Models.Response;

namespace CustomerAPI;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<Customer, CustomerResponseModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
    }
}