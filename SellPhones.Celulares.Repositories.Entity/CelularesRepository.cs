using SellPhones.Celulares.Business;
using SellPhones.Celulares.Data.Entity.Context;
using SellPhones.Celulares.Repositories.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SellPhones.Celulares.Repositories.Entity
{
    public class CelularesRepository : RepositoryGenericEntity<Celular, int>
    {
        public CelularesRepository(CelularDbContext context)
            : base(context)
        { 
        
        }

        public override List<Celular> Select()
        {
            return _context.Set<Celular>().Include(p => p.Marca).ToList();
        }

        public override Celular SelectById(int id)
        { 
            return _context.Set<Celular>().Include(p => p.Marca)
                .SingleOrDefault(f => f.IdCelular == id);
        }
    }
    
}
