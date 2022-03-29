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
    public class EuroGroupsController : ControllerBase
    {
        private readonly Euro2020Context _context;

        public EuroGroupsController(Euro2020Context context)
        {
            _context = context;
        }

        // GET: api/EuroGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EuroGroup>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: api/EuroGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EuroGroup>> GetEuroGroup(int id)
        {
            var euroGroup = await _context.Groups.FindAsync(id);

            if (euroGroup == null)
            {
                return NotFound();
            }

            return euroGroup;
        }

        // PUT: api/EuroGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEuroGroup(int id, EuroGroup euroGroup)
        {
            if (id != euroGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(euroGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EuroGroupExists(id))
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

        // POST: api/EuroGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EuroGroup>> PostEuroGroup(EuroGroup euroGroup)
        {
            _context.Groups.Add(euroGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEuroGroup", new { id = euroGroup.Id }, euroGroup);
        }

        // DELETE: api/EuroGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEuroGroup(int id)
        {
            var euroGroup = await _context.Groups.FindAsync(id);
            if (euroGroup == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(euroGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EuroGroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
