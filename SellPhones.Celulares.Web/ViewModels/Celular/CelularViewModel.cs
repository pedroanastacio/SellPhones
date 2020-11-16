using SellPhones.Celulares.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellPhones.Celulares.Web.ViewModels.Celular
{
    public class CelularViewModel
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdCelular { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        [MaxLength(50, ErrorMessage = "O modelo deve der no máximo 50 caracteres.")]
        [Display(Name = "Modelo do celular")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Selecione uma marca")]
        [Display(Name = "Nome da marca")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória")]
        [MaxLength(50, ErrorMessage = "A cor deve der no máximo 30 caracteres.")]
        [Display(Name = "Cor do celular")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Display(Name = "Preço do celular")]
        public float Preco { get; set; }

        [IMEI(ErrorMessage = "O IMEI inserido é inválido.")]
        [MaxLength(15, ErrorMessage = "O IMEI deve ter no máximo 15 caracteres.")]
        [Display(Name = "IMEI do celular")]
        public string Imei { get; set; }
    }
}