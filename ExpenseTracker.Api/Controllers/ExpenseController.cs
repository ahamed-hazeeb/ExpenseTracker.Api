using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.DTO;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExpenseController(AppDbContext context)
        {
            _context = context;
        }

        // ----------------------------
        // GET: api/expense/user/1
        // ----------------------------
        [HttpGet("user.{userId}")]
        public IActionResult GetExpenseByUser(int userId)
        {
            var expenses = _context.Expenses
                .Include(e => e.Category)
                .Where(e=>e.UserId ==userId)
                .Select(e=>new ExpenseResponseDto
                { Id = e.Id,
                Titel = e.Titel,
                Amount = e.Amount,
                Date = e.Date,
                UserId = e.UserId,
                CategoryName = e.Category.Name
                })
                .OrderByDescending(e=>e.Date)
                .ToList();

            return Ok(expenses);
        }

        // ----------------------------
        // POST: api/expense
        // ----------------------------
        [HttpPost]
        public IActionResult CreateExpense (CreateExpenseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_context.Users.Any(u => u.Id == dto.UserId))
                return BadRequest("Invalid User");

            if (!_context.Categories.Any(c => c.Id == dto.CategoryID))
                return BadRequest("Invalid Category");

            var expense = new Expense
            {
                Titel = dto.Titel,
                Amount = dto.Amount,
                Date = dto.Date,
                UserId = dto.UserId,
                CategoryID = dto.CategoryID
            };
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            var response = new ExpenseResponseDto
            {
                Id = expense.Id,
                Titel = expense.Titel,
                Amount = expense.Amount,
                Date = expense.Date,
                UserId = expense.UserId,
                CategoryName = _context.Categories
                                .Where(c => c.Id == expense.CategoryID)
                                .Select(c => c.Name)
                                .First()
            };
            return CreatedAtAction(nameof(GetExpenseByUser), new { userId = expense.UserId }, response);
        }
        // ----------------------------
        // PUT: api/expense/5
        // ----------------------------
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id, UpdateExpenseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var expense = _context.Expenses.Find(id);

            if (expense == null)
                return NotFound();

            expense.Titel = dto.Titel;
            expense.Amount = dto.Amount;
            expense.Date = dto.Date;
            expense.CategoryID = dto.CategoryID;

            _context.SaveChanges();

            return NoContent();
        }

        // ----------------------------
        // DELETE: api/expense/5
        // ----------------------------
        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);

            if (expense == null)
                return NotFound();

            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
