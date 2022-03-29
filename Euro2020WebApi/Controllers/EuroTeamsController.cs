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
    public class EuroTeamsController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroTeamsController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroTeam>>> GetTeams()
        {
            return await _context.Teams
                .Include(x => x.FK_Country)
                .ToListAsync();
        }

        // GET: api/EuroTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroTeam>> GetEuroTeam(int id)
        {
            var euroTeam = await _context.Teams.FindAsync(id);

            if (euroTeam == null)
            {
                return NotFound();
            }

            return euroTeam;
        }

        // PUT: api/EuroTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroTeam(int id, EuroTeam euroTeam)
        {
            if (id != euroTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroTeamExists(id))
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

        // POST: api/EuroTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroTeam>> PostEuroTeam(EuroTeam euroTeam)
        {
            _context.Teams.Add(euroTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroTeam", new { id = euroTeam.Id }, euroTeam);
        }

        // DELETE: api/EuroTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroTeam(int id)
        {
            var euroTeam = await _context.Teams.FindAsync(id);
            if (euroTeam == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(euroTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroTeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
