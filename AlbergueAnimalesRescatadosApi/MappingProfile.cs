using AutoMapper;
using Domain.Entities;
using Shared.Dto;
using Shared.Dto.Adopter;
using Shared.Dto.Volunteer;

namespace AlbergueAnimalesRescatadosApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<Adopter, AdopterDto>();
            CreateMap<Volunteer, VolunteerDto>();
        }
    }
}
