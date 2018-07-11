using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace velocity.Generic
{
    public interface IDataRepository<T,K> where T : class, IPK<K>
    {

        Task<IEnumerable<T>> GetAll();
        Task<T> Get(K id);
        Task<IEnumerable<T>> Find(JObject key);
        Task Add(T obj);
        Task Add(IEnumerable<T> list);
        Task Delete(K id);
        Task Delete(IEnumerable<T> list);
        Task Update(T obj);
        Task Update(IEnumerable<T> list);
    }
}
