using AutoMapper;
using Domain.Entities;
using Shared.Dto;

namespace AlbergueAnimalesRescatadosApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDto>();
        }
    }
}
