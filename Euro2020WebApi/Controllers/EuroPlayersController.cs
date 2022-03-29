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
    public class EuroPlayersController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroPlayersController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroPlayer>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET: api/EuroPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroPlayer>> GetEuroPlayer(int id)
        {
            var euroPlayer = await _context.Players.FindAsync(id);

            if (euroPlayer == null)
            {
                return NotFound();
            }

            return euroPlayer;
        }

        // PUT: api/EuroPlayers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroPlayer(int id, EuroPlayer euroPlayer)
        {
            if (id != euroPlayer.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroPlayerExists(id))
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

        // POST: api/EuroPlayers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroPlayer>> PostEuroPlayer(EuroPlayer euroPlayer)
        {
            _context.Players.Add(euroPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroPlayer", new { id = euroPlayer.Id }, euroPlayer);
        }

        // DELETE: api/EuroPlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroPlayer(int id)
        {
            var euroPlayer = await _context.Players.FindAsync(id);
            if (euroPlayer == null)
            {
                return NotFound();
            }

            _context.Players.Remove(euroPlayer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroPlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
