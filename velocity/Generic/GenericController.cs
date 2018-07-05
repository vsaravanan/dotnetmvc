using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttributeRouting;

namespace velocity.Generic
{

    [Produces("application/json")]
    [RoutePrefix("[controller]")]
    public abstract class GenericController<M, T, K> : Controller where M : IDataRepository<T, K> where T : class, IPK<K>
    {

        public M mgr { get; set; }

        public GenericController(M repo)
        {
            mgr = repo;
        }

        // GET: api/User
        //[HttpGet]
        [Route("[controller]")]
        public Task<IEnumerable<T>> Get()
        {
            return mgr.GetAll();

        }

        // GET: api/User/5

        //[HttpGet("[controller]/{id}", Name = "Get")]
        [Route("[controller]/{id:int}")]
        public Task<T> Get(K id)
        {
            return mgr.Get(id);
        }

        // GET: api/User/Find
        //[HttpGet("Find/{key}", Name = "Find")]
        [Route("[controller]/Find/{key}")]
        public T Find(K key)
        {
            return mgr.Find(key);
        }

        // POST: api/User
        [Route("[controller]")]
        [HttpPost]
        public async void Post([FromBody] T value)
        {
            await mgr.Add(value);

        }


        // DELETE: api/User/5
        [Route("[controller]/Delete/{id}")]
        [HttpDelete]
        //[HttpDelete("{id}")]
        public async void Delete(K id)
        {
            await mgr.Delete(id);
        }

        // PUT: api/User
        [Route("[controller]")]
        [HttpPut]
        public async void Put([FromBody]T value)
        {
            await mgr.Update(value);

        }
    }
}
