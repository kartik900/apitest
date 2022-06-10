namespace WebApplication1.Models
{
    public class AccountRequest
    {
        public string? AccountHolderName { get; set; }
        public AccountType AccountType { get; set; }
    }

    public enum AccountType
    {
        Savings = 1,
        Current = 2,
    }

    public class AccountResponse
    {
        public int AccountId { get; set; }
    }
}
