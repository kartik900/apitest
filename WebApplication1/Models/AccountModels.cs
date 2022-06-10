namespace WebApplication1.Models
{
    public class AccountRequest
    {
        public string? AccountHolderName { get; set; }
        public AccountType AccountType { get; set; }
        public string? IFSCCode { get; set; }
    }

    public class AccountResponse
    {
        public int AccountId { get; set; }
    }

    public class UserRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressPinCode { get; set; }
    }





}
