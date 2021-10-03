using AutoMapper;
using ProAgil.Domain;
using ProAgil.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.Api.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>();
            CreateMap<Palestrante, PalestranteDto>();
            CreateMap<Lote, LoteDto>();
            CreateMap<RedesSociais, RedeSocialDto>();
        }
    }
}
