using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Celulares.Business
{
    public class Celular
    {
        public int IdCelular { get; set; }
        public string Modelo { get; set; }
        public virtual Marca Marca { get; set; }
        public int IdMarca { get; set; }
        public string Cor { get; set; }
        public float Preco { get; set; }
        public string Imei { get; set; }
    }
}
