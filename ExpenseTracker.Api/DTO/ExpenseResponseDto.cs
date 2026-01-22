namespace ExpenseTracker.Api.DTO
{
    public class ExpenseResponseDto
    {
        public int Id { get; set; }
        public string Titel { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
