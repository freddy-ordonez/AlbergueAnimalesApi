using AutoMapper;
using Domain.Entities;
using Shared.Dto;
using Shared.Dto.Adopter;
using Shared.Dto.Animal;
using Shared.Dto.Volunteer;

namespace AlbergueAnimalesRescatadosApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalForCreationDto, Animal>();
            CreateMap<AnimalForUpdateDto, Animal>().ReverseMap();

            CreateMap<Adopter, AdopterDto>();
            CreateMap<AdopterForCreationDto, Adopter>();
            CreateMap<AdopterForUpdateDto, Adopter>();
            
            CreateMap<Volunteer, VolunteerDto>();
            CreateMap<VolunteerForCreationDto, Volunteer>();
            CreateMap<VolunteerForUpdateDto, Volunteer>();
        }
    }
}
