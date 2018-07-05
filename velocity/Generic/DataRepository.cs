using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using velocity.Extn;
using velocity.Models;

namespace velocity.Generic

{
    public abstract class DataRepository<T, K> : IDataRepository<T, K> where T : class, IPK<K>
    {


        VelocityContext ctx;


        public DataRepository(VelocityContext c)
        {
            ctx = c;
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await ctx.Set<T>().AsNoTracking().ToListAsync();
            return list;
        }

        public async Task<T> Get(K id)
        {
            var row = await ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(b => b.id.Equals(id));
            return row;
        }

        public T Find(K key)
        {
            return ctx.Set<T>()
                .AsNoTracking()
                .Where(e => e.id.Equals(key))
                .SingleOrDefault();
        }

        public async Task Add(T obj)
        {

            ctx.Set<T>().Add(obj);
            await ctx.SaveChangesAsync();

        }

        public async Task Delete(K id)
        {
            var entity = ctx.Set<T>().Find(id);
            ctx.Set<T>().Remove(entity);
            await ctx.SaveChangesAsync();

        }


        public async Task Update(T obj)
        {

            if (! TypeHelper.Defined(obj.id)) return;
            ctx.Set<T>().Update(obj);
            await ctx.SaveChangesAsync();

        }

    }
}


