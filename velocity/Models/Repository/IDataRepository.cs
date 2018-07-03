using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace velocity.Models.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(U id);
        TEntity Find(string key);
        long Add(TEntity b);
        long Update(U id, TEntity b);
        long Delete(U id);
    }
}
