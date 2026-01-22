using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titel { get; set; }= string.Empty;
        
        [Range(0.01,double.MaxValue)]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CategoryID { get; set; }
        public Category? Category { get; set; } = null!;
    }
}
