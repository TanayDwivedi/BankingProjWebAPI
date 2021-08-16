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
    public class UserTransactionsController : ControllerBase
    {
        private readonly BANKINGContext _context;

        public UserTransactionsController(BANKINGContext context)
        {
            _context = context;
        }

        // GET: api/UserTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTransaction>>> GetUserTransactions()
        {
            return await _context.UserTransactions.ToListAsync();
        }

        // GET: api/UserTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTransaction>> GetUserTransaction(long id)
        {
            var userTransaction = await _context.UserTransactions.FindAsync(id);

            if (userTransaction == null)
            {
                return NotFound();
            }

            return userTransaction;
        }

        // PUT: api/UserTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTransaction(long id, UserTransaction userTransaction)
        {
            if (id != userTransaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(userTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTransactionExists(id))
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

        // POST: api/UserTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTransaction>> PostUserTransaction(UserTransaction userTransaction)
        {
            _context.UserTransactions.Add(userTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTransaction", new { id = userTransaction.TransactionId }, userTransaction);
        }

        // DELETE: api/UserTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTransaction(long id)
        {
            var userTransaction = await _context.UserTransactions.FindAsync(id);
            if (userTransaction == null)
            {
                return NotFound();
            }

            _context.UserTransactions.Remove(userTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTransactionExists(long id)
        {
            return _context.UserTransactions.Any(e => e.TransactionId == id);
        }
    }
}
