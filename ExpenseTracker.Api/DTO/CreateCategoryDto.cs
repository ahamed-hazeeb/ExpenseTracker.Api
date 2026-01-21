using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.DTO
{
    public class CreateCategoryDto
    {
         [Required]
            [MinLength(3)]
            public string Name { get; set; }
       
    }
}
