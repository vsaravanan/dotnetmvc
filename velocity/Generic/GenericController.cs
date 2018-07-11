using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttributeRouting;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Net;

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

        protected ObjectResult CheckAuthentication()
        {
            var token = HttpContext.Session.GetString(Constants.Constants.SessionId);
            if (String.IsNullOrEmpty(token))
                return StatusCode((int)HttpStatusCode.Unauthorized, "Invalid login");
            else
                return null;
        }

        // GET: api/User
        [Route("[controller]")]
        public async Task<Object> Get()
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            return await mgr.GetAll();
        }

        // GET: api/User/5
        //[HttpGet("[controller]/{id}", Name = "Get")]
        [Route("[controller]/{id:int}")]
        public async Task<Object> Get(K id)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            return await mgr.Get(id);

        }

        // GET: api/User/Find
        //[HttpGet("Find/{key}", Name = "Find")]
        [Route("[controller]/Find")]
        [HttpPost]
        public async Task<Object> Find([FromBody] JObject key)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            return await mgr.Find(key);
        }

        // POST: api/User
        [Route("[controller]")]
        [HttpPost]
        public async Task<Object> Post([FromBody] T value)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            await mgr.Add(value);
            return Constants.Constants.Success;

        }

        [Route("[controller]/AddMulti")]
        [HttpPost]
        public async Task<Object> Post([FromBody] IEnumerable<T> value)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            await mgr.Add(value);
            return Constants.Constants.Success;

        }

        // DELETE: api/User/5
        [Route("[controller]/Delete/{id}")]
        [HttpDelete]
        public async Task<Object> Delete(K id)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            await mgr.Delete(id);
            return Constants.Constants.Success;
        }

        [Route("[controller]/Delete")]
        [HttpDelete]
        public async Task<Object> Delete([FromBody] T obj)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            T[] t = { obj };
            await mgr.Delete(t);
            return Constants.Constants.Success;
        }

        [Route("[controller]/DeleteMulti")]
        [HttpDelete]
        public async Task<Object> Delete([FromBody] IEnumerable<T> value)
        {

            var error = CheckAuthentication();
            if (error != null) return error;
            await mgr.Delete(value);
            return Constants.Constants.Success;

        }

        // PUT: api/User
        [Route("[controller]")]
        [HttpPut]
        public async Task<Object> Put([FromBody]T value)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            await mgr.Update(value);
            return Constants.Constants.Success;

        }

        [Route("[controller]/UpdateMulti")]
        [HttpPut]
        public async Task<Object> Put([FromBody] IEnumerable<T> value)
        {
            var error = CheckAuthentication();
            if (error != null) return error;
            await mgr.Update(value);
            return Constants.Constants.Success;

        }
    }
}
