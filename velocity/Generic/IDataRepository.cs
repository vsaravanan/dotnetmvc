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
        Task Delete(K id);
        Task Update(T obj);
    }
}
