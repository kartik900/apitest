using WebApplication1.DBModels;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AccountRepository : IAccountRepository
    {
        private BankContext _bankContext;

        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<int> CreateAccount(AccountRequest accountRequest)
        {
            var account = new Account() { AccountHolderName = accountRequest.AccountHolderName, AccountType = (int)accountRequest.AccountType };
            await _bankContext.Accounts.AddAsync(account);
            await _bankContext.SaveChangesAsync();
            return account.AccountId;
        }

        public async Task<List<Account>> GetAllAccounts()
        {            
            return await Task.FromResult(_bankContext.Accounts.ToList());
        }
    }
}
