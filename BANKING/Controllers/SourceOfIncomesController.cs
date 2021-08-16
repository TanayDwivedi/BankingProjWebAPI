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
    public class SourceOfIncomesController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public SourceOfIncomesController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/SourceOfIncomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SourceOfIncome>>> GetSourceOfIncomes()
        {
            return await _context.SourceOfIncomes.ToListAsync();
        }

        // GET: api/SourceOfIncomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SourceOfIncome>> GetSourceOfIncome(string id)
        {
            var sourceOfIncome = await _context.SourceOfIncomes.FindAsync(id);

            if (sourceOfIncome == null)
            {
                return NotFound();
            }

            return sourceOfIncome;
        }

        // PUT: api/SourceOfIncomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSourceOfIncome(string id, SourceOfIncome sourceOfIncome)
        {
            if (id != sourceOfIncome.SourceType)
            {
                return BadRequest();
            }

            _context.Entry(sourceOfIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SourceOfIncomeExists(id))
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

        // POST: api/SourceOfIncomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SourceOfIncome>> PostSourceOfIncome(SourceOfIncome sourceOfIncome)
        {
            _context.SourceOfIncomes.Add(sourceOfIncome);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SourceOfIncomeExists(sourceOfIncome.SourceType))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSourceOfIncome", new { id = sourceOfIncome.SourceType }, sourceOfIncome);
        }

        // DELETE: api/SourceOfIncomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSourceOfIncome(string id)
        {
            var sourceOfIncome = await _context.SourceOfIncomes.FindAsync(id);
            if (sourceOfIncome == null)
            {
                return NotFound();
            }

            _context.SourceOfIncomes.Remove(sourceOfIncome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SourceOfIncomeExists(string id)
        {
            return _context.SourceOfIncomes.Any(e => e.SourceType == id);
        }
    }
}
