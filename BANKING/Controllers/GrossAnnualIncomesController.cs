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
    public class GrossAnnualIncomesController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public GrossAnnualIncomesController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/GrossAnnualIncomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrossAnnualIncome>>> GetGrossAnnualIncomes()
        {
            return await _context.GrossAnnualIncomes.ToListAsync();
        }

        // GET: api/GrossAnnualIncomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrossAnnualIncome>> GetGrossAnnualIncome(string id)
        {
            var grossAnnualIncome = await _context.GrossAnnualIncomes.FindAsync(id);

            if (grossAnnualIncome == null)
            {
                return NotFound();
            }

            return grossAnnualIncome;
        }

        // PUT: api/GrossAnnualIncomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrossAnnualIncome(string id, GrossAnnualIncome grossAnnualIncome)
        {
            if (id != grossAnnualIncome.AnnualIncome)
            {
                return BadRequest();
            }

            _context.Entry(grossAnnualIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrossAnnualIncomeExists(id))
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

        // POST: api/GrossAnnualIncomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GrossAnnualIncome>> PostGrossAnnualIncome(GrossAnnualIncome grossAnnualIncome)
        {
            _context.GrossAnnualIncomes.Add(grossAnnualIncome);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GrossAnnualIncomeExists(grossAnnualIncome.AnnualIncome))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGrossAnnualIncome", new { id = grossAnnualIncome.AnnualIncome }, grossAnnualIncome);
        }

        // DELETE: api/GrossAnnualIncomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrossAnnualIncome(string id)
        {
            var grossAnnualIncome = await _context.GrossAnnualIncomes.FindAsync(id);
            if (grossAnnualIncome == null)
            {
                return NotFound();
            }

            _context.GrossAnnualIncomes.Remove(grossAnnualIncome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrossAnnualIncomeExists(string id)
        {
            return _context.GrossAnnualIncomes.Any(e => e.AnnualIncome == id);
        }
    }
}
