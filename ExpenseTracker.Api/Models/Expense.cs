namespace ExpenseTracker.Api.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
