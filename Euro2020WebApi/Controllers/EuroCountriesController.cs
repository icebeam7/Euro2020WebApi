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
    public class EuroCountriesController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroCountriesController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroCountries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroCountry>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/EuroCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroCountry>> GetEuroCountry(int id)
        {
            var euroCountry = await _context.Countries.FindAsync(id);

            if (euroCountry == null)
            {
                return NotFound();
            }

            return euroCountry;
        }

        // PUT: api/EuroCountries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroCountry(int id, EuroCountry euroCountry)
        {
            if (id != euroCountry.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroCountryExists(id))
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

        // POST: api/EuroCountries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroCountry>> PostEuroCountry(EuroCountry euroCountry)
        {
            _context.Countries.Add(euroCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroCountry", new { id = euroCountry.Id }, euroCountry);
        }

        // DELETE: api/EuroCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroCountry(int id)
        {
            var euroCountry = await _context.Countries.FindAsync(id);
            if (euroCountry == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(euroCountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroCountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
