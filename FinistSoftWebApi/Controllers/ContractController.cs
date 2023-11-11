using FinistSoftWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinistSoftWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        private ApplicationContext _context;
        public ContractController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> Get(int userId)
        {
            Contract? contract = await _context.Contracts.FirstOrDefaultAsync(con => con.UserId == userId);
            if (contract == null)
                return NotFound();
            return Ok(contract);
        }

        [HttpPost]
        public ActionResult Add(Contract contract)
        {
            _context.Contracts.Add(contract);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(Contract contract)
        {
            if (_context.Contracts.Any(c => c.Id == contract.Id)) 
            {
                _context.Contracts.Update(contract);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpDelete("{contractId}")]
        public ActionResult Delete(int contractId) 
        {
            Contract? contract = _context.Contracts.FirstOrDefault(c => c.Id == contractId);
            if (contract == null)
                return BadRequest();
            
            _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return Ok();
        }
    }
}
