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
    public class EuroCoachesController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroCoachesController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroCoaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroCoach>>> GetCoaches()
        {
            return await _context.Coaches.ToListAsync();
        }

        // GET: api/EuroCoaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroCoach>> GetEuroCoach(int id)
        {
            var euroCoach = await _context.Coaches.FindAsync(id);

            if (euroCoach == null)
            {
                return NotFound();
            }

            return euroCoach;
        }

        // PUT: api/EuroCoaches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroCoach(int id, EuroCoach euroCoach)
        {
            if (id != euroCoach.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroCoach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroCoachExists(id))
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

        // POST: api/EuroCoaches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroCoach>> PostEuroCoach(EuroCoach euroCoach)
        {
            _context.Coaches.Add(euroCoach);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroCoach", new { id = euroCoach.Id }, euroCoach);
        }

        // DELETE: api/EuroCoaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroCoach(int id)
        {
            var euroCoach = await _context.Coaches.FindAsync(id);
            if (euroCoach == null)
            {
                return NotFound();
            }

            _context.Coaches.Remove(euroCoach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroCoachExists(int id)
        {
            return _context.Coaches.Any(e => e.Id == id);
        }
    }
}
