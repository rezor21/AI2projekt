using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AI2projektraporty.Data;
using AI2projektraporty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace AI2projektraporty.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [EnableCors("AI2Cors")]
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AI2Context _context;

        public ReportsController(AI2Context context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: api/Reports

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
           
            var report = _context.Reports.Where(m => m.UserId == _userManager.GetUserId(User));

            if (report == null)
            {
                return NotFound(report);
            }

            return Ok(report);
        }



        [Route("/Reports")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Reports/Pdf/{id}")]
        public IActionResult Pdf([FromRoute] int id)
        {
            var transactions = GetTransactionsForReport(id);
            string date = "";
            double transactionsSum = 0;
            Report report = _context.Reports.SingleOrDefault(m => m.Id == id);
            ICollection<string> titles = new List<string>();
            ICollection<double> amounts = new List<double>();


            foreach (var t in transactions)
            { 
                titles.Add(t.Title);
                amounts.Add(t.Amount);
                transactionsSum += t.Amount;
            }


            if (transactions.Count != 0)
                switch (report.Type)
            {
                
                case Models.Type.Yearly :
                    {
                        date = transactions.First().Date.Year.ToString();
                        break;
                    }
                case Models.Type.Monthly:
                    {
                        date = transactions.First().Date.Month.ToString() + "." + transactions.First().Date.Year.ToString();
                        break;
                    }
                case Models.Type.Daily:
                    {
                        date = transactions.First().Date.Day.ToString() + "." +  transactions.First().Date.Month.ToString() + "." + transactions.First().Date.Year.ToString();
                        break;
                    }
            }
            

            var model = new PdfViewModel
            {
                Report = report,
                Transactions = transactions,
                Titles = titles,
                Amounts = amounts,
                Date = date,
                Sum = transactionsSum
            };

            return View(model);
        }

        [Route("/api/Reports/Pdf/{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> DataToPdf([FromRoute] int id)
        {
            var transactions = GetTransactionsForReport(id);
         
            return Ok(transactions);
        }


        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = await _context.Reports.SingleOrDefaultAsync(m => m.Id == id && m.UserId == _userManager.GetUserId(User));

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        public ICollection<Transaction> GetTransactionsForReport(int id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            var report = _context.Reports.SingleOrDefault(m => m.Id == id && m.UserId == _userManager.GetUserId(User));
            var reporttransactions = _context.ReportTransaction.Where(m => m.ReportId == id).ToList();
            ICollection<Transaction> transactions = new List<Transaction>();
            foreach (var transaction in reporttransactions)
            {
                transactions.Add( _context.Transactions.SingleOrDefault(m => m.Id == transaction.TransactionId));
            }

            return transactions;
        }



        // POST: api/Reports
        [HttpPost]
        public async Task<IActionResult> PostReport([FromBody] Report report)
        {
            var date = DateTime.Now;
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            report.UserId = _userManager.GetUserId(User);

            _context.Reports.Add(report);
            _context.SaveChanges();
            List<Transaction> transactions = new List<Transaction>();

           switch (report.Type)
            {
                case Models.Type.Daily:
                    // transactions = _context.Transactions.Where(m => m.Date <= DateTime.Now && m.Date >= (new DateTime(year - 1, month, day))).ToList();
                    transactions = _context.Transactions.Where(m => m.Date.Day == DateTime.Now.Day).ToList();
                    break;
                case Models.Type.Monthly:
                    transactions = _context.Transactions.Where(m => m.Date.Month == DateTime.Now.Month).ToList();
                    break;
                case Models.Type.Yearly:
                    transactions = _context.Transactions.Where(m => m.Date.Year == DateTime.Now.Year).ToList();
                    break;
            }
            

            foreach (var transaction in transactions)
            {
                if (_context.Transactions.Find(transaction.Id) != null)
                {
                    _context.ReportTransaction.Add(new ReportTransaction { ReportId = report.Id, TransactionId = transaction.Id });
                }
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReport", new { id = report.Id }, report);
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = await _context.Reports.SingleOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();

            return Ok(report);
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }

        [Route("addTransactions/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> AddTransactionsToReport([FromRoute] int id, [FromBody] List<Transaction> transactions)
        {
            Report report = _context.Reports.SingleOrDefault(m => m.Id == id);
            if(report.ReportTransaction == null)
            {
                report.ReportTransaction = new List<ReportTransaction>();
            }
            
            foreach (var transaction in transactions)
            {
                if (_context.Transactions.Find(transaction.Id) != null)
                {
                    report.ReportTransaction.Add(new ReportTransaction { Report = report, TransactionId = transaction.Id });
                }
                else
                {
                    return NotFound();
                }
            }
            
           


            
            _context.SaveChanges();
            return Ok();
        }
    }
}