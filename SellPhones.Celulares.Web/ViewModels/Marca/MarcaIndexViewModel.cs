using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellPhones.Celulares.Web.ViewModels.Marca
{
    public class MarcaIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome da marca")]
        public string Nome { get; set; }
    }
}