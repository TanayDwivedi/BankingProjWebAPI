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
    public class LocationCityStatesController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public LocationCityStatesController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/LocationCityStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationCityState>>> GetLocationCityStates()
        {
            return await _context.LocationCityStates.ToListAsync();
        }

        // GET: api/LocationCityStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationCityState>> GetLocationCityState(string id)
        {
            var locationCityState = await _context.LocationCityStates.FindAsync(id);

            if (locationCityState == null)
            {
                return NotFound();
            }

            return locationCityState;
        }

        // PUT: api/LocationCityStates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationCityState(string id, LocationCityState locationCityState)
        {
            if (id != locationCityState.City)
            {
                return BadRequest();
            }

            _context.Entry(locationCityState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationCityStateExists(id))
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

        // POST: api/LocationCityStates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationCityState>> PostLocationCityState(LocationCityState locationCityState)
        {
            _context.LocationCityStates.Add(locationCityState);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocationCityStateExists(locationCityState.City))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocationCityState", new { id = locationCityState.City }, locationCityState);
        }

        // DELETE: api/LocationCityStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationCityState(string id)
        {
            var locationCityState = await _context.LocationCityStates.FindAsync(id);
            if (locationCityState == null)
            {
                return NotFound();
            }

            _context.LocationCityStates.Remove(locationCityState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationCityStateExists(string id)
        {
            return _context.LocationCityStates.Any(e => e.City == id);
        }
    }
}
