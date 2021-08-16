using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BANKING.LTIMode;

namespace BANKING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationTypesController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public OccupationTypesController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/OccupationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccupationType>>> GetOccupationTypes()
        {
            return await _context.OccupationTypes.ToListAsync();
        }

        // GET: api/OccupationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccupationType>> GetOccupationType(string id)
        {
            var occupationType = await _context.OccupationTypes.FindAsync(id);

            if (occupationType == null)
            {
                return NotFound();
            }

            return occupationType;
        }

        // PUT: api/OccupationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccupationType(string id, OccupationType occupationType)
        {
            if (id != occupationType.Otype)
            {
                return BadRequest();
            }

            _context.Entry(occupationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccupationTypeExists(id))
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

        // POST: api/OccupationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OccupationType>> PostOccupationType(OccupationType occupationType)
        {
            _context.OccupationTypes.Add(occupationType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OccupationTypeExists(occupationType.Otype))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOccupationType", new { id = occupationType.Otype }, occupationType);
        }

        // DELETE: api/OccupationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupationType(string id)
        {
            var occupationType = await _context.OccupationTypes.FindAsync(id);
            if (occupationType == null)
            {
                return NotFound();
            }

            _context.OccupationTypes.Remove(occupationType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OccupationTypeExists(string id)
        {
            return _context.OccupationTypes.Any(e => e.Otype == id);
        }
    }
}
