using ExpenseTracker.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.DTO
{
    public class UpdateExpenseDto
    {
        [Required]
        public string Titel { get; set; } = string.Empty;
        [Range(0.01,double.MaxValue)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
