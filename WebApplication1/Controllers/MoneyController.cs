using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.DBModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public MoneyController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost(Name = "CreateAccount")]
        public async Task<AccountResponse> CreateAccount(AccountRequest account)
        {
            return new AccountResponse
            {
                AccountId = await _accountRepository.CreateAccount(account)
            };
        }

        [HttpGet(Name = "GetAllAccounts")]
        public async Task<List<Account>> GetAccounts()
        {
            return await _accountRepository.GetAllAccounts();
        }


    }
}
