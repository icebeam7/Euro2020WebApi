using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Euro2020WebApi.Context;
using Euro2020WebApi.Models;

namespace Euro2020WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EuroStadiumsController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroStadiumsController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroStadiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroStadium>>> GetStadiums()
        {
            return await _context.Stadiums.ToListAsync();
        }

        // GET: api/EuroStadiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroStadium>> GetEuroStadium(int id)
        {
            var euroStadium = await _context.Stadiums.FindAsync(id);

            if (euroStadium == null)
            {
                return NotFound();
            }

            return euroStadium;
        }

        // PUT: api/EuroStadiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroStadium(int id, EuroStadium euroStadium)
        {
            if (id != euroStadium.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroStadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroStadiumExists(id))
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

        // POST: api/EuroStadiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroStadium>> PostEuroStadium(EuroStadium euroStadium)
        {
            _context.Stadiums.Add(euroStadium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroStadium", new { id = euroStadium.Id }, euroStadium);
        }

        // DELETE: api/EuroStadiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroStadium(int id)
        {
            var euroStadium = await _context.Stadiums.FindAsync(id);
            if (euroStadium == null)
            {
                return NotFound();
            }

            _context.Stadiums.Remove(euroStadium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroStadiumExists(int id)
        {
            return _context.Stadiums.Any(e => e.Id == id);
        }
    }
}
