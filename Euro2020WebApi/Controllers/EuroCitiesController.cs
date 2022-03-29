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
    public class EuroCitiesController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroCitiesController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroCity>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/EuroCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroCity>> GetEuroCity(int id)
        {
            var euroCity = await _context.Cities.FindAsync(id);

            if (euroCity == null)
            {
                return NotFound();
            }

            return euroCity;
        }

        // PUT: api/EuroCities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroCity(int id, EuroCity euroCity)
        {
            if (id != euroCity.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroCityExists(id))
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

        // POST: api/EuroCities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroCity>> PostEuroCity(EuroCity euroCity)
        {
            _context.Cities.Add(euroCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroCity", new { id = euroCity.Id }, euroCity);
        }

        // DELETE: api/EuroCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroCity(int id)
        {
            var euroCity = await _context.Cities.FindAsync(id);
            if (euroCity == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(euroCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroCityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
