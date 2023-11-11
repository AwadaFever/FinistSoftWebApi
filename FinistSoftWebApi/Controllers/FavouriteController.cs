using FinistSoftWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace FinistSoftWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavouriteController : ControllerBase
    {
        readonly ApplicationContext _context;
        public FavouriteController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{UserId}")]
        public ActionResult Get(int UserId)
        {
            List<Favourite> favourites = _context.Favourites.Where(f => f.UserId == UserId).ToList();
            return Ok(favourites);
        }

        [HttpPost]
        public ActionResult Add(Favourite favourite) 
        {
            _context.Favourites.Add(favourite);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Favourite favourite)
        {
            if (_context.Favourites.Any(f => f.Id == favourite.Id))
            {
                _context.Favourites.Update(favourite);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpDelete("{favouriteId}")]
        public ActionResult Delete(int favouriteId)
        {
            Favourite? favourite = _context.Favourites.FirstOrDefault(f => f.Id == favouriteId);
            if (favourite == null)
                return BadRequest();

            _context.Favourites.Remove(favourite);
            _context.SaveChanges();
            return Ok();
        }

    }
}
