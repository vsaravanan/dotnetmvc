using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttributeRouting;
using System;
using velocity.DataManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

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
        [Route("[controller]/Find")]
        [HttpPost]
        public Task<IEnumerable<T>> Find([FromBody] JObject key)
        {

            return mgr.Find(key);
        }

        // POST: api/User
        [Route("[controller]")]
        [HttpPost]
        public async Task Post([FromBody] T value)
        {
            await mgr.Add(value);

        }

        [Route("[controller]/AddMulti")]
        [HttpPost]
        public async Task Post([FromBody] IEnumerable<T> value)
        {
            await mgr.Add(value);

        }

        // DELETE: api/User/5
        [Route("[controller]/Delete/{id}")]
        [HttpDelete]
        public async Task Delete(K id)
        {
            await mgr.Delete(id);
        }

        [Route("[controller]/Delete")]
        [HttpDelete]
        public async Task Delete([FromBody] T obj)
        {
            T[] t = {obj};
            await mgr.Delete(t);
        }

        [Route("[controller]/DeleteMulti")]
        [HttpDelete]
        public async Task Delete([FromBody] IEnumerable<T> value)
        {
            await mgr.Delete(value);
        }

        // PUT: api/User
        [Route("[controller]")]
        [HttpPut]
        public async Task Put([FromBody]T value)
        {
            await mgr.Update(value);

        }

        [Route("[controller]/UpdateMulti")]
        [HttpPut]
        public async Task Put([FromBody] IEnumerable<T> value)
        {
            await mgr.Update(value);

        }
    }
}
