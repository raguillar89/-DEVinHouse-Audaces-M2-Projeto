using AutoMapper;
using LabFashion.DTOs;
using LabFashion.Models;

namespace LabFashion.Mapping
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<ClothingCollection, ClothingCollectionDTO>().ReverseMap();
        }
    }
}
