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
    public class UserOpenAccountsController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public UserOpenAccountsController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/UserOpenAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOpenAccount>>> GetUserOpenAccounts()
        {
            return await _context.UserOpenAccounts.ToListAsync();
        }

        // GET: api/UserOpenAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOpenAccount>> GetUserOpenAccount(string id)
        {
            var userOpenAccount = await _context.UserOpenAccounts.FindAsync(id);

            if (userOpenAccount == null)
            {
                return NotFound();
            }

            return userOpenAccount;
        }

        // PUT: api/UserOpenAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOpenAccount(string id, UserOpenAccount userOpenAccount)
        {
            if (id != userOpenAccount.AadharCardNumber)
            {
                return BadRequest();
            }

            _context.Entry(userOpenAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOpenAccountExists(id))
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

        // POST: api/UserOpenAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserOpenAccount>> PostUserOpenAccount(UserOpenAccount userOpenAccount)
        {
            _context.UserOpenAccounts.Add(userOpenAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserOpenAccountExists(userOpenAccount.AadharCardNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserOpenAccount", new { id = userOpenAccount.AadharCardNumber }, userOpenAccount);
        }

        // DELETE: api/UserOpenAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOpenAccount(string id)
        {
            var userOpenAccount = await _context.UserOpenAccounts.FindAsync(id);
            if (userOpenAccount == null)
            {
                return NotFound();
            }

            _context.UserOpenAccounts.Remove(userOpenAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserOpenAccountExists(string id)
        {
            return _context.UserOpenAccounts.Any(e => e.AadharCardNumber == id);
        }
    }
}
