using cstest.Services;
using cstest.Models;
using Microsoft.AspNetCore.Mvc;

namespace cstest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingAccountOperationController : ControllerBase
    {
        private readonly IAccountOperation _accountOperation;
        public SavingAccountOperationController(Func<String, IAccountOperation> accountOperation)
        {
            _accountOperation = accountOperation("saving");
        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            try
            {
                var account = await _accountOperation.deposit(request.AccountId, request.Amount);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] DepositRequest request)
        {
            try
            {
                var account = await _accountOperation.withdraw(request.AccountId, request.Amount);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] DepositRequest request)
        {
            try
            {
                var account = await _accountOperation.transfer(request.AccountId, request.ToAccountId, request.Amount);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("balance/{id}")]
        public async Task<IActionResult> Balance(int id)
        {
            try
            {
                var balance = await _accountOperation.Balance(id);
                return Ok(balance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
        }
    }
    }
}