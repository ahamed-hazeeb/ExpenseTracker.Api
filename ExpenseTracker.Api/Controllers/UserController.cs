using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.DTO;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _context.Users
                .Select(u=> new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email

                })
                .ToList();
            return Ok(users);
        }


        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };
           

            _context.Users.Add(user);
            _context.SaveChanges();
            var Response = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, Response);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var user = _context.Users.Find(id);
            
            if (user == null)
                return NotFound();

            user.Name = dto.Name;
            user.Email = dto.Email;


            _context.SaveChanges();

            var Response = new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            return Ok(Response);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}