using WebApplication1.DBModels;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IAccountRepository
    {
        Task<int> CreateAccount(AccountRequest accountRequest);
        Task<List<Account>> GetAllAccounts();
    }
}
