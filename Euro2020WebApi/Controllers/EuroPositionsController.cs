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
    public class EuroPositionsController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroPositionsController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroPosition>>> GetPositions()
        {
            return await _context.Positions.ToListAsync();
        }

        // GET: api/EuroPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroPosition>> GetEuroPosition(int id)
        {
            var euroPosition = await _context.Positions.FindAsync(id);

            if (euroPosition == null)
            {
                return NotFound();
            }

            return euroPosition;
        }

        // PUT: api/EuroPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroPosition(int id, EuroPosition euroPosition)
        {
            if (id != euroPosition.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroPositionExists(id))
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

        // POST: api/EuroPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroPosition>> PostEuroPosition(EuroPosition euroPosition)
        {
            _context.Positions.Add(euroPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroPosition", new { id = euroPosition.Id }, euroPosition);
        }

        // DELETE: api/EuroPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroPosition(int id)
        {
            var euroPosition = await _context.Positions.FindAsync(id);
            if (euroPosition == null)
            {
                return NotFound();
            }

            _context.Positions.Remove(euroPosition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroPositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}
