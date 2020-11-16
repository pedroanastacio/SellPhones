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
    public class MarcasRepository : RepositoryGenericEntity<Marca, int>
    {
        public MarcasRepository(CelularDbContext context)
            : base(context)
        {

        }

        public override List<Marca> Select()
        {
            return _context.Set<Marca>().Include(p => p.Celulares).ToList();
        }

        public override Marca SelectById(int id)
        {
            return _context.Set<Marca>().Include(p => p.Celulares)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
