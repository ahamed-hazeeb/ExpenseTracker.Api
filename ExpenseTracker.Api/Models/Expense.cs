using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
