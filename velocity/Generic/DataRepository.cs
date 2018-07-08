using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
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

        private static string Tsearch(IList<string> sql, JToken key)
        {


            while (key != null && key.HasValues)
            {
                string tmp = key.First.Value<string>();
                string tmplower = "";

                if (tmp != null)
                {
                    tmp = tmp.TrimStart();
                    tmplower = tmp.ToLower();
                }

                string[] opsNull = { "null", "not null" };
                string[] opsIsNull = { "is null", "is not null" };
                string[] operators3 = { "!=", "<=", ">=", "<",">","=" };

                if (Array.IndexOf(opsNull, tmplower) > -1)
                    sql.Add(key.Path + " is " + tmplower);
                else if (Array.IndexOf(opsIsNull, tmplower) > -1)
                    sql.Add(key.Path + " " + tmplower);
                else if (tmplower.StartsWith("not like"))
                    sql.Add(key.Path + " not like '" + tmp.Substring(8).TrimStart() + "'");
                else if (tmplower.StartsWith("not"))
                    sql.Add(key.Path + " not like '" + tmp.Substring(3).TrimStart() + "'");
                else if (tmplower.StartsWith("like"))
                    sql.Add(key.Path + " like '" + tmp.Substring(4).TrimStart() + "'");
                else if (Array.IndexOf(operators3, tmplower.Substring(0, 2)) > -1)
                    sql.Add(key.Path + " " + tmplower.Substring(0, 2) + " '" + tmp.Substring(2).TrimStart() + "'");
                else if (Array.IndexOf(operators3, tmplower.Substring(0, 1)) > -1)
                    sql.Add(key.Path + " " + tmplower.Substring(0, 1) + " '" + tmp.Substring(1).TrimStart() + "'");
                else if (tmp.Contains("%"))
                    sql.Add(key.Path + " like '" + tmp + "'");
                else
                    sql.Add(key.Path + " = '" + tmp + "'");

                return Tsearch(sql, key.Next);
            }

            string newsql = "";
            if (sql.Count != 0)
            {
                newsql = " where " +  string.Join(" and ", sql);
            }


            return newsql;
        }

        public async Task<IEnumerable<T>> Find(JObject key)
        {

            string where = Tsearch(new List<string>(), key.First);

            string fullsql = "select * from " + "\"" + typeof(T).Name + "\"" + where;

            System.Diagnostics.Debug.WriteLine(fullsql);

            var list = await ctx.Set<T>().FromSql<T>(fullsql).AsNoTracking().ToListAsync();
            return list;

        }

        public async Task Add(T obj)
        {

            ctx.Set<T>().Add(obj);
            await ctx.SaveChangesAsync();

        }

        public async Task Add(IEnumerable<T> list)
        {

            ctx.Set<T>().AddRange(list);
            await ctx.SaveChangesAsync();

        }

        public async Task Delete(K id)
        {
            var entity = ctx.Set<T>().Find(id);
            ctx.Set<T>().Remove(entity);
            await ctx.SaveChangesAsync();

        }

        public async Task Delete(IEnumerable<T> list)
        {
            var row = list.FirstOrDefault(obj => !TypeHelper.Defined(obj.id));
            if (row != null)
                return;
            ctx.Set<T>().RemoveRange(list);
            await ctx.SaveChangesAsync();

        }

        public async Task Update(T obj)
        {

            if (! TypeHelper.Defined(obj.id)) return;
            ctx.Set<T>().Update(obj);
            await ctx.SaveChangesAsync();

        }

        public async Task Update(IEnumerable<T> list)
        {
            var row = list.FirstOrDefault(obj => !TypeHelper.Defined(obj.id));
            if (row != null)
                return;
            ctx.Set<T>().UpdateRange(list);
            await ctx.SaveChangesAsync();

        }

    }
}


