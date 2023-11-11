using FinistSoftWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinistSoftWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ApplicationContext _context;
        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("validate/{login}/{password}")]
        public async Task<ActionResult> Login(string login, string password)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
                return NotFound();
            if (user.Password != password)
                return BadRequest();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            if (user == null)
                return BadRequest();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        

        [HttpPut]
        public ActionResult Update(User user)
        {
            if (_context.Users.Any(u => u.Id == user.Id))
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return BadRequest();

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
