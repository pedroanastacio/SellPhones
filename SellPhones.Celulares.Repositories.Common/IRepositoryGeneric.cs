using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Celulares.Repositories.Common
{
    public interface IRepositoryGeneric<TEntity, TKey>
        where TEntity : class
    {
        List<TEntity> Select();
        TEntity SelectById(TKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(TKey id);
    }
}
