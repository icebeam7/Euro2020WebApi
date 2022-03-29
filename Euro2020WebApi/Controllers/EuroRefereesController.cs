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
    public class EuroRefereesController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroRefereesController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroReferees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroReferee>>> GetReferees()
        {
            return await _context.Referees.ToListAsync();
        }

        // GET: api/EuroReferees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroReferee>> GetEuroReferee(int id)
        {
            var euroReferee = await _context.Referees.FindAsync(id);

            if (euroReferee == null)
            {
                return NotFound();
            }

            return euroReferee;
        }

        // PUT: api/EuroReferees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroReferee(int id, EuroReferee euroReferee)
        {
            if (id != euroReferee.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroReferee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroRefereeExists(id))
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

        // POST: api/EuroReferees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroReferee>> PostEuroReferee(EuroReferee euroReferee)
        {
            _context.Referees.Add(euroReferee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroReferee", new { id = euroReferee.Id }, euroReferee);
        }

        // DELETE: api/EuroReferees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroReferee(int id)
        {
            var euroReferee = await _context.Referees.FindAsync(id);
            if (euroReferee == null)
            {
                return NotFound();
            }

            _context.Referees.Remove(euroReferee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroRefereeExists(int id)
        {
            return _context.Referees.Any(e => e.Id == id);
        }
    }
}
