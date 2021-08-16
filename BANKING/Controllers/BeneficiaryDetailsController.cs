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
    public class BeneficiaryDetailsController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public BeneficiaryDetailsController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/BeneficiaryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeneficiaryDetail>>> GetBeneficiaryDetails()
        {
            return await _context.BeneficiaryDetails.ToListAsync();
        }

        // GET: api/BeneficiaryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeneficiaryDetail>> GetBeneficiaryDetail(int id)
        {
            var beneficiaryDetail = await _context.BeneficiaryDetails.FindAsync(id);

            if (beneficiaryDetail == null)
            {
                return NotFound();
            }

            return beneficiaryDetail;
        }

        // PUT: api/BeneficiaryDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiaryDetail(int id, BeneficiaryDetail beneficiaryDetail)
        {
            if (id != beneficiaryDetail.BeneficiaryAccNo)
            {
                return BadRequest();
            }

            _context.Entry(beneficiaryDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryDetailExists(id))
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

        // POST: api/BeneficiaryDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BeneficiaryDetail>> PostBeneficiaryDetail(BeneficiaryDetail beneficiaryDetail)
        {
            _context.BeneficiaryDetails.Add(beneficiaryDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BeneficiaryDetailExists(beneficiaryDetail.BeneficiaryAccNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBeneficiaryDetail", new { id = beneficiaryDetail.BeneficiaryAccNo }, beneficiaryDetail);
        }

        // DELETE: api/BeneficiaryDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficiaryDetail(int id)
        {
            var beneficiaryDetail = await _context.BeneficiaryDetails.FindAsync(id);
            if (beneficiaryDetail == null)
            {
                return NotFound();
            }

            _context.BeneficiaryDetails.Remove(beneficiaryDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficiaryDetailExists(int id)
        {
            return _context.BeneficiaryDetails.Any(e => e.BeneficiaryAccNo == id);
        }
    }
}
