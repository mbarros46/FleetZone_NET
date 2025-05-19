using AutoMapper;
using MottuCrudAPI.Application.DTOs;
using MottuCrudAPI.Domain.Entities;

namespace MottuCrudAPI.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Moto mappings
            CreateMap<Moto, MotoDTO>()
                .ForMember(dest => dest.PatioNome, opt => opt.MapFrom(src => src.Patio != null ? src.Patio.Nome : null));
            
            CreateMap<CreateMotoDTO, Moto>();
            CreateMap<UpdateMotoDTO, Moto>();

            // Patio mappings
            CreateMap<Patio, PatioDTO>()
                .ForMember(dest => dest.MotosCount, opt => opt.MapFrom(src => src.Motos.Count));
            
            CreateMap<CreatePatioDTO, Patio>();
            CreateMap<UpdatePatioDTO, Patio>();
        }
    }
} 