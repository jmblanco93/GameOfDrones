using ApplicationCore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers.Resources;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Game, GameResource>();
            CreateMap<Player, PlayerResource>();

            //API Resource to Domain
            CreateMap<RoundResource, Round>();
        }
    }
}
