using FinistSoftWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinistSoftWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardControllers : ControllerBase
    {
        private readonly ApplicationContext _context;
        public CardControllers(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{contractId}")]
        public ActionResult Get(int contractId)
        {
            List<Card> cards = _context.Cards.Where(c => c.ContractId == contractId).ToList();
            return Ok(cards);
        }

        [HttpDelete("{cardId}")]
        public ActionResult Delete(int cardId)
        {
            Card? card = _context.Cards.FirstOrDefault(c => c.ContractId == cardId);
            if (card == null)
                return BadRequest();
            else
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpPost]
        public ActionResult Add(Card card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Card card)
        {
            if (_context.Cards.Any(c => c.Id == card.Id))
            {
                _context.Cards.Update(card);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();


        }
    }
}
