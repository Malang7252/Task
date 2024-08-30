using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Service.Dtos.Accounts;
using Task.Service.Services.Accounts;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDto accountDto)
        {
            var response = await _accountService.CreateAccountAsync(accountDto);
            return ReturnFormattedResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountDto accountDto)
        {
            var response = await _accountService.UpdateAccountAsync(accountDto);
            return ReturnFormattedResponse(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var response = await _accountService.DeleteAccountAsync(id);
            return ReturnFormattedResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAccountById(Guid id)
        {
            var response = await _accountService.GetAccountByIdAsync(id);
            return ReturnFormattedResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _accountService.GetAllAccountsAsync();
            return ReturnFormattedResponse(response);
        }
    }
}
