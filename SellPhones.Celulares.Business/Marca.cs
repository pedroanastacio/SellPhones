using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Celulares.Business
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Celular> Celulares { get; set; }
    }
}
