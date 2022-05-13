using AutoMapper;
using Sales.Entities.DTO;
using Sales.Entities.Models;

namespace Sales.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        CreateMap<Customer, CustomerDto>().ReverseMap();

        CreateMap<VSearchCustomer, CustomerDto>().ReverseMap();
        }
    }
}
