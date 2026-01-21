using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.DTO
{
    public class UpdateCategoryDto
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
