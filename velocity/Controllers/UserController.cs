using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using velocity.Models;
using velocity.Models.Repository;

namespace velocity.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private IDataRepository<User, int> _iRepo;

        public UserController(IDataRepository<User, int> repo)
        {
            _iRepo = repo;
        }


        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _iRepo.GetAll();

        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _iRepo.Get(id);
        }

        // GET: api/User/Find
        [HttpGet("Find/{key}", Name = "Find")]
        public User Find(string key)
        {
            return _iRepo.Find(key);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User value)
        {
            _iRepo.Add(value);

        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            _iRepo.Update(value.id, value);


        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}
