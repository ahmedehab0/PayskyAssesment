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
            try {
                var newAccount = await _accountService.CreateAccount(account);
                return Ok(newAccount);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            try {
                var account = await _accountService.GetAccountById(id);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] Account account)
        {
            try {
                var updatedAccount = await _accountService.UpdateAccount(account);
                if (updatedAccount == null)
                {
                    return NotFound();
                }
                return Ok(updatedAccount);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try {
                var deletedAccount = await _accountService.DeleteAccount(id);
                if (deletedAccount == null)
                {
                    return NotFound();
                }
                return Ok(deletedAccount);
            } catch (Exception e) {
                return BadRequest(e.Message);
        }
    }
    }
}