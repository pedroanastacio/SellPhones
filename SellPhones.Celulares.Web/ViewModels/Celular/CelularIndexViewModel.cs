using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellPhones.Celulares.Web.ViewModels.Celular
{
    public class CelularIndexViewModel
    {
        public int IdCelular { get; set; }
        [Display(Name="Modelo do celular")]
        public string Modelo { get; set; }
        [Display(Name = "Marca do celular")]
        public string NomeMarca { get; set; }
        [Display(Name = "Cor do celular")]
        public string Cor { get; set; }
        [Display(Name = "Preço do celular")]
        public float Preco { get; set; }
        [Display(Name = "IMEI do celular")]
        public string Imei { get; set; }
    }
}