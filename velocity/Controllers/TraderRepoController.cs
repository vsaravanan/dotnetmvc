using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using velocity.Models;
using velocity.Repository;

namespace velocity.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TraderRepoController : Controller
    {
        public ITraderRepository TradersRepo { get; set; }

        public TraderRepoController(ITraderRepository _repo)
        {
            TradersRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Trader> GetAll()
        {
            return TradersRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetTraders")]
        public IActionResult GetById(string id)
        {
            var item = TradersRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Trader item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TradersRepo.Add(item);
            return CreatedAtRoute("GetTraders", new { Controller = "Traders", id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Trader item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = TradersRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            TradersRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TradersRepo.Remove(id);
        }
    }
}