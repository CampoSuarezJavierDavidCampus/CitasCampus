using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    protected MappingProfiles()
    {
        CreateMap<Genero,GeneroDto>()
            .ForMember(dest=>dest.Id_Gender,opt => opt.MapFrom(src => src.Id))
            .ForMember(dest=>dest.Gender,opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest=>dest.Prefix,opt => opt.MapFrom(src => src.Abreviatura))
            .ForMember(dest=>dest.Users,opt => opt.MapFrom(src => src.Usuarios))
            .ReverseMap();
    }
}