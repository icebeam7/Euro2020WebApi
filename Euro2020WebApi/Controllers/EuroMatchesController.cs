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
    public class EuroMatchesController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroMatchesController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroMatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroMatch>>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }

        // GET: api/EuroMatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroMatch>> GetEuroMatch(int id)
        {
            var euroMatch = await _context.Matches.FindAsync(id);

            if (euroMatch == null)
            {
                return NotFound();
            }

            return euroMatch;
        }

        // PUT: api/EuroMatches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroMatch(int id, EuroMatch euroMatch)
        {
            if (id != euroMatch.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroMatchExists(id))
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

        // POST: api/EuroMatches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroMatch>> PostEuroMatch(EuroMatch euroMatch)
        {
            _context.Matches.Add(euroMatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroMatch", new { id = euroMatch.Id }, euroMatch);
        }

        // DELETE: api/EuroMatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroMatch(int id)
        {
            var euroMatch = await _context.Matches.FindAsync(id);
            if (euroMatch == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(euroMatch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroMatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
