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
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CelularViewModel, Celular>();
            Mapper.CreateMap<MarcaViewModel, Marca>();
        }
    }
}