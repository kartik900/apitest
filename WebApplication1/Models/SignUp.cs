using WebApplication1.DBModels;

namespace WebApplication1.Models
{
    public class SignUpRequest
    {
        public UserRequest UserRequest { get; set; }
        public AccountRequest AccountRequest { get; set; }
        public decimal InitialDeposit { get; set; }
    }

    public class SignUpResponse
    {
        public int UseriD { get; set; }
        public int AccountID { get; set; }
        public int UserAccountMappingID { get; set; }
        public int TransactionID { get; set; }
        public decimal AccountBalance { get; set; }
        public string Status { get; set; }
    }


}
