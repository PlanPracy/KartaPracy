using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.App_Start
{
    using AutoMapper;
    using Dtos;
    using Models;
    using Repozytorium.Models;

    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Sklep, SklepDto>();
            Mapper.CreateMap<SklepDto, Sklep>();
        }
    }
}