using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AI2projektraporty.Data;
using AI2projektraporty.Models;
using Microsoft.AspNetCore.Cors;

namespace AI2projektraporty.Controllers
{
    [Produces("application/json")]
    [EnableCors("AI2Cors")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly AI2Context _context;

        public TransactionsController(AI2Context context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions;
        }
        
        [Route("/Transactions")]
        public IActionResult Index()
        {
            return View();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await _context.Transactions.SingleOrDefaultAsync(m => m.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [Route("date/{year}")]
        [HttpGet("{year}")]
        public async Task<IActionResult> GetTransactionByYear([FromRoute] int year)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = _context.Transactions.Where(m => m.Date.Year == year);


            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [Route("date/{year}/{month}")]
        [HttpGet("{year}, {month}")]
        public async Task<IActionResult> GetTransactionByMonth([FromRoute] int year, [FromRoute] int month)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = _context.Transactions.Where(m => m.Date.Year == year && m.Date.Month == month);


            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [Route("date/{year}/{month}/{day}")]
        [HttpGet("{year}, {month}, {day}")]
        public async Task<IActionResult> GetTransactionByDay([FromRoute] int year, [FromRoute] int month, [FromRoute] int day)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var transaction = _context.Transactions.Where(m => m.Date.Year == year && m.Date.Month == month && m.Date.Day == day);


            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction([FromRoute] int id, [FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        [HttpPost]
        public async Task<IActionResult> PostTransaction([FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            transaction.Date = DateTime.Now;

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await _context.Transactions.SingleOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}