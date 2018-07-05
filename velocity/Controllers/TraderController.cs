using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using velocity.Models;

namespace velocity.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class TraderController : Controller
    {
        private readonly VelocityContext _context;

        public TraderController(VelocityContext context)
        {
            _context = context;
        }

        // GET: api/Traders
        [HttpGet]
        public IEnumerable<Trader> GetTrader()
        {
            return _context.Trader;
        }

        // GET: api/Traders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrader([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trader = await _context.Trader.SingleOrDefaultAsync(m => m.id == id);

            if (trader == null)
            {
                return NotFound();
            }

            return Ok(trader);
        }

        // PUT: api/Traders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrader([FromRoute] int id, [FromBody] Trader trader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trader.id)
            {
                return BadRequest();
            }

            _context.Entry(trader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Traders
        [HttpPost]
        public async Task<IActionResult> PostTrader([FromBody] Trader trader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trader.Add(trader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrader", new { id = trader.id }, trader);
        }

        // DELETE: api/Traders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrader([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trader = await _context.Trader.SingleOrDefaultAsync(m => m.id == id);
            if (trader == null)
            {
                return NotFound();
            }

            _context.Trader.Remove(trader);
            await _context.SaveChangesAsync();

            return Ok(trader);
        }

        private bool TraderExists(int id)
        {
            return _context.Trader.Any(e => e.id == id);
        }
    }
}