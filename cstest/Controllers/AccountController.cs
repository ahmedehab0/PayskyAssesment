using cstest.Services;
using Microsoft.AspNetCore.Mvc;
using cstest.Models;

namespace cstest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            var newAccount = await _accountService.CreateAccount(account);
            return Ok(newAccount);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] Account account)
        {
            var updatedAccount = await _accountService.UpdateAccount(account);
            if (updatedAccount == null)
            {
                return NotFound();
            }
            return Ok(updatedAccount);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _accountService.DeleteAccount(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
    }
}