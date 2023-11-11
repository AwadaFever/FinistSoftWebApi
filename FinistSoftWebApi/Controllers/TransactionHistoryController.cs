using FinistSoftWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinistSoftWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionHistoryController : ControllerBase
    {
        private ApplicationContext _context;
        public TransactionHistoryController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("{ContractId}")]
        public ActionResult Get(int ContractId)
        {
            List<TransactionHistory> transactionHistories = _context.TransactionHistories.Where(th => th.SenderId == ContractId).ToList();
            return Ok(transactionHistories);
        }

        [HttpPost]
        public ActionResult Add(TransactionHistory transaction)
        {
            _context.TransactionHistories.Add(transaction);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(TransactionHistory transaction)
        {
            if (_context.TransactionHistories.Any(th => th.Id == transaction.Id))
            {
                _context.TransactionHistories.Update(transaction);
                _context.SaveChanges();
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpDelete("{transactionId}")]
        public ActionResult Delete(int transactionId)
        {
            TransactionHistory? transaction = _context.TransactionHistories.FirstOrDefault(th => th.Id == transactionId);
            if (transaction == null)
                return BadRequest();

            _context.TransactionHistories.Remove(transaction);
            _context.SaveChanges();
            return Ok();
        }

    }
}
