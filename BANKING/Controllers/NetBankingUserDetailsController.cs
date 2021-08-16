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
    public class NetBankingUserDetailsController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public NetBankingUserDetailsController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/NetBankingUserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NetBankingUserDetail>>> GetNetBankingUserDetails()
        {
            return await _context.NetBankingUserDetails.ToListAsync();
        }

        // GET: api/NetBankingUserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NetBankingUserDetail>> GetNetBankingUserDetail(int id)
        {
            var netBankingUserDetail = await _context.NetBankingUserDetails.FindAsync(id);

            if (netBankingUserDetail == null)
            {
                return NotFound();
            }

            return netBankingUserDetail;
        }

        // PUT: api/NetBankingUserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetBankingUserDetail(int id, NetBankingUserDetail netBankingUserDetail)
        {
            if (id != netBankingUserDetail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(netBankingUserDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetBankingUserDetailExists(id))
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

        // POST: api/NetBankingUserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NetBankingUserDetail>> PostNetBankingUserDetail(NetBankingUserDetail netBankingUserDetail)
        {
            _context.NetBankingUserDetails.Add(netBankingUserDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNetBankingUserDetail", new { id = netBankingUserDetail.UserId }, netBankingUserDetail);
        }

        // DELETE: api/NetBankingUserDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNetBankingUserDetail(int id)
        {
            var netBankingUserDetail = await _context.NetBankingUserDetails.FindAsync(id);
            if (netBankingUserDetail == null)
            {
                return NotFound();
            }

            _context.NetBankingUserDetails.Remove(netBankingUserDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NetBankingUserDetailExists(int id)
        {
            return _context.NetBankingUserDetails.Any(e => e.UserId == id);
        }
    }
}
