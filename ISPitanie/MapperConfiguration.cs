using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPitanie.Models;
using AutoMapper;
using DAL.Entities;

namespace ISPitanie
{
    class MapperConfiguration
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.UnitName, src => src.MapFrom(x => x.Unit.Name));
            });
        }
    }
}
