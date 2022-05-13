using AutoMapper;
using Sales.Entities.Models;
using Sales.Entities.DTO.AECDTO;

namespace Sales.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Person, PersonAECDTO>().ReverseMap();
            CreateMap<Store, StoreAECDTO>().ReverseMap();
            CreateMap<SalesTerritory, SalesTeritoryAECDTO>().ReverseMap();

        }
    }
}
