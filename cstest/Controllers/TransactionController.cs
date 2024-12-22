using cstest.Services;
using Microsoft.AspNetCore.Mvc;
using cstest.Models;
using System.Threading.Tasks;

namespace cstest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            try {
                var newTransaction = await _transactionService.CreateTransaction(transaction);
                return Ok(newTransaction);
            } catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            try {
                var transaction = await _transactionService.GetTransactionById(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            } catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try {
                var transaction = await _transactionService.DeleteTransaction(id);
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            } catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}