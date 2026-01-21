using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.DTO;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var categories = _context.Categories
                .Select(u=>new CategoryResponseDto
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToList();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            var Response = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return CreatedAtAction(nameof(GetCategory),new { id = category.Id },Response);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id ,UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            category.Name = dto.Name;

            _context.SaveChanges();

            var Response = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(Response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
                
            
        }
    }
}
