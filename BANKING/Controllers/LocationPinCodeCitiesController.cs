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
    public class LocationPinCodeCitiesController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public LocationPinCodeCitiesController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/LocationPinCodeCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationPinCodeCity>>> GetLocationPinCodeCities()
        {
            return await _context.LocationPinCodeCities.ToListAsync();
        }

        // GET: api/LocationPinCodeCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationPinCodeCity>> GetLocationPinCodeCity(string id)
        {
            var locationPinCodeCity = await _context.LocationPinCodeCities.FindAsync(id);

            if (locationPinCodeCity == null)
            {
                return NotFound();
            }

            return locationPinCodeCity;
        }

        // PUT: api/LocationPinCodeCities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationPinCodeCity(string id, LocationPinCodeCity locationPinCodeCity)
        {
            if (id != locationPinCodeCity.Pincode)
            {
                return BadRequest();
            }

            _context.Entry(locationPinCodeCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationPinCodeCityExists(id))
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

        // POST: api/LocationPinCodeCities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationPinCodeCity>> PostLocationPinCodeCity(LocationPinCodeCity locationPinCodeCity)
        {
            _context.LocationPinCodeCities.Add(locationPinCodeCity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LocationPinCodeCityExists(locationPinCodeCity.Pincode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocationPinCodeCity", new { id = locationPinCodeCity.Pincode }, locationPinCodeCity);
        }

        // DELETE: api/LocationPinCodeCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationPinCodeCity(string id)
        {
            var locationPinCodeCity = await _context.LocationPinCodeCities.FindAsync(id);
            if (locationPinCodeCity == null)
            {
                return NotFound();
            }

            _context.LocationPinCodeCities.Remove(locationPinCodeCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationPinCodeCityExists(string id)
        {
            return _context.LocationPinCodeCities.Any(e => e.Pincode == id);
        }
    }
}
