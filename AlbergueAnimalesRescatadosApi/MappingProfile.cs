using AutoMapper;
using Domain.Entities;
using Shared.Dto;
using Shared.Dto.Adopter;

namespace AlbergueAnimalesRescatadosApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<Adopter, AdopterDto>();
        }
    }
}
