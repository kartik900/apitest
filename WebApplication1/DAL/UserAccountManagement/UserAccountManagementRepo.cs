using WebApplication1.DBModels;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class UserAccountManagementRepo : IUserAccountManagementRepo
    {
        private BankContext _bankContext;

        public UserAccountManagementRepo(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<SignUpResponse> UserSignUp(SignUpRequest signUpRequest)
        {
            int newUserID = await CreateUserDetails(signUpRequest.UserRequest);
            if (newUserID <= 0)
                return new SignUpResponse() { Status = "Failed"};

            int newAccountID = await CreateAccount(signUpRequest.AccountRequest);
            if (newAccountID <= 0)
                return new SignUpResponse() { Status = "Failed" };

            int userAccountMappingId = await CreateUserAcountMapping(newUserID, newAccountID);
            if (userAccountMappingId <= 0)
                return new SignUpResponse() { Status = "Failed" };

            int transactionID = await CreateTransaction(newAccountID, signUpRequest.InitialDeposit);
            if (transactionID <= 0)
                return new SignUpResponse() { Status = "Failed" };

            decimal newAccountBalance = await UpdateBalance(newAccountID, signUpRequest.InitialDeposit);
            if (newAccountBalance <= 0)
                return new SignUpResponse() { Status = "Failed" };

            return new SignUpResponse()
            {
                UseriD = newUserID,
                AccountBalance = newAccountBalance,
                TransactionID = transactionID,
                AccountID = newAccountID,
                UserAccountMappingID = userAccountMappingId,
                Status = "Success"
            };
        }

        #region Private Methods

        private async Task<int> CreateAccount(AccountRequest accountRequest)
        {
            Account newAccount = new()
            {
                AccountHolderName = accountRequest.AccountHolderName,
                AccountType = (int)accountRequest.AccountType,
                Ifsccode = accountRequest.IFSCCode,
                IsActive = true,
                CreatedOn = DateTime.Now,
            };
            await Task.FromResult(_bankContext.Accounts.Add(newAccount));
            await _bankContext.SaveChangesAsync();
            return newAccount.AccountId;
        }

        private async Task<int> CreateUserDetails(UserRequest userRequest)
        {
            User user = new()
            {
                UserName = userRequest.UserName,
                Email = userRequest.Email,
                PhoneNumber = userRequest.PhoneNumber,
                AddressCity = userRequest.AddressCity,
                AddressPinCode = userRequest.AddressPinCode,
                DateOfBirth = userRequest.DateOfBirth
            };
            await _bankContext.Users.AddAsync(user);
            await _bankContext.SaveChangesAsync();
            return user.UserId;
        }

        private async Task<int> CreateUserAcountMapping(int userId,int accountId)
        {
            UserAccountMapping userAccountMapping = new()
            {
                UserId = userId,
                AccountId = accountId
            };
            await _bankContext.UserAccountMappings.AddAsync(userAccountMapping);
            await _bankContext.SaveChangesAsync();
            return userAccountMapping.UserAccountMappingId;
        }

        private async Task<int> CreateTransaction(int accountId, decimal amount)
        {
            Transaction transaction = new()
            {
                Amount = amount,
                AccountId = accountId,
                TransactionDate = DateTime.Now,
                TransactionFlow = TransactionFlow.Credited.ToString(),
                TransactionMode = TransactionMode.Cash.ToString(),
                TransactionStatusId = (int)TransactionStatusEnum.TransactionSuccessful,
            };
            await _bankContext.Transactions.AddAsync(transaction);
            await _bankContext.SaveChangesAsync();
            return transaction.TransactionId;
        }

        private async Task<decimal> UpdateBalance(int accountId, decimal amount)
        {
            Balance balance = new()
            {
                AccountId = accountId,
                Amount = amount,
            };
            await Task.FromResult(_bankContext.Balances.Add(balance));
            await _bankContext.SaveChangesAsync();
            return balance.BalanceId>=0 ? amount : 0;
        }

        #endregion
    }
}
