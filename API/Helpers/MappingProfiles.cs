using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entidades;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Lugar, LugarDto>()
                    .ForMember(d => d.Pais, o=>o.MapFrom(s => s.Pais.Nombre))
                    .ForMember(c => c.Categoria, o=> o.MapFrom(s=>s.Categoria.Nombre))
                    .ForMember(d => d.ImageUrl, o=>o.MapFrom<LugarUrlResolver>());

        }
    }
}