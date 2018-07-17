using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AttributeRouting;
using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;
using velocity.Models;

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

        protected void CheckAuthentication()
        {
            if ( Constants.Constants.IsDev ) return;
            var token = HttpContext.Session.GetString(Constants.Constants.SessionId);
            if (String.IsNullOrEmpty(token))
            {
                ErrorData errors = new ErrorData((int)HttpStatusCode.Unauthorized, "Invalid login");
                TempData["Error"] = JsonConvert.SerializeObject(errors);
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.Unauthorized);
                //return RedirectToAction("Error","Home");
            }

        }



        // GET: api/User
        [Route("[controller]")]
        public async Task<IEnumerable<T>> Get()
        {
            CheckAuthentication();
            return await mgr.GetAll();
        }

        // GET: api/User/5
        //[HttpGet("[controller]/{id}", Name = "Get")]
        [Route("[controller]/{id:int}")]
        public async Task<T> Get(K id)
        {

            CheckAuthentication();
            return await mgr.Get(id);

        }

        // GET: api/User/Find
        //[HttpGet("Find/{key}", Name = "Find")]
        [Route("[controller]/Find")]
        [HttpPost]
        public async Task<IEnumerable<T>> Find([FromBody] JObject key)
        {

            CheckAuthentication();
            return await mgr.Find(key);
        }

        // POST: api/User
        [Route("[controller]")]
        [HttpPost]
        public async Task Post([FromBody] T value)
        {
            CheckAuthentication();
            await mgr.Add(value);

        }

        [Route("[controller]/AddMulti")]
        [HttpPost]
        public async Task Post([FromBody] IEnumerable<T> value)
        {
            CheckAuthentication();
            await mgr.Add(value);
        }

        // DELETE: api/User/5
        [Route("[controller]/Delete/{id}")]
        [HttpDelete]
        public async Task Delete(K id)
        {
            CheckAuthentication();
            await mgr.Delete(id);
        }

        [Route("[controller]/Delete")]
        [HttpDelete]
        public async Task Delete([FromBody] T obj)
        {
            CheckAuthentication();
            T[] t = { obj };
            await mgr.Delete(t);
        }

        [Route("[controller]/DeleteMulti")]
        [HttpDelete]
        public async Task Delete([FromBody] IEnumerable<T> value)
        {

            CheckAuthentication();
            await mgr.Delete(value);

        }

        // PUT: api/User
        [Route("[controller]")]
        [HttpPut]
        public async Task Put([FromBody]T value)
        {
            CheckAuthentication();
            await mgr.Update(value);

        }

        [Route("[controller]/UpdateMulti")]
        [HttpPut]
        public async Task Put([FromBody] IEnumerable<T> value)
        {
            CheckAuthentication();
            await mgr.Update(value);

        }
    }
}
