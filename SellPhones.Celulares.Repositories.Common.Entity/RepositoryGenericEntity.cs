using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Celulares.Repositories.Common.Entity
{
    public class RepositoryGenericEntity<TEntity, TKey> : IRepositoryGeneric<TEntity, TKey>
        where TEntity : class
    {
        protected DbContext _context; 

        public RepositoryGenericEntity(DbContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteById(TKey id)
        {
            TEntity entity = SelectById(id);
            Delete(entity);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual List<TEntity> Select()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity SelectById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
