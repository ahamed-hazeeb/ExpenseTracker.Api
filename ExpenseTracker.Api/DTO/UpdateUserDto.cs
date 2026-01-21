using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.DTO
{
    public class UpdateUserDto
    {

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }
}
