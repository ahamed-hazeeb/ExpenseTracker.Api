using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();   
    }
}
