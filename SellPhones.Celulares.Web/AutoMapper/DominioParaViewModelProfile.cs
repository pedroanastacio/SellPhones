using AutoMapper;
using SellPhones.Celulares.Business;
using SellPhones.Celulares.Web.ViewModels.Celular;
using SellPhones.Celulares.Web.ViewModels.Marca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellPhones.Celulares.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Marca, MarcaIndexViewModel>();

            Mapper.CreateMap<Marca, MarcaViewModel>();

            Mapper.CreateMap<Celular , CelularIndexViewModel>()
                .ForMember(p => p.NomeMarca, opt =>
                {
                    opt.MapFrom(src => src.Marca.Nome);
                });
            Mapper.CreateMap<Celular, CelularViewModel>();

            

        }
    }
}