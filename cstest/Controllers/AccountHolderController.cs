using cstest.Services;
using Microsoft.AspNetCore.Mvc;
using cstest.Models;

namespace cstest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountHolderController : ControllerBase
    {
        private readonly IAccountHolderService _accountHolderService;
        public AccountHolderController(IAccountHolderService accountHolderService)
        {
            _accountHolderService = accountHolderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccountHolder([FromBody] AccountHolder accountHolder)
        {
            try
            {
                var newAccountHolder = await _accountHolderService.CreateAccountHolder(accountHolder);
                return Ok(newAccountHolder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountHolderById(int id)
        {
            var accountHolder = await _accountHolderService.GetAccountHolderById(id);
            if (accountHolder == null)
            {
                return NotFound();
            }
            return Ok(accountHolder);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountHolder(int id, [FromBody] AccountHolder accountHolder)
        {
            var updatedAccountHolder = await _accountHolderService.UpdateAccountHolder(accountHolder);
            if (updatedAccountHolder == null)
            {
                return NotFound();
            }
            return Ok(updatedAccountHolder);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountHolder(int id)
        {
            var accountHolder = await _accountHolderService.DeleteAccountHolder(id);
            if (accountHolder == null)
            {
                return NotFound();
            }
            return Ok(accountHolder);
        }
    }
}