using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class Account
    {
        public Account()
        {
            Balances = new HashSet<Balance>();
            Transactions = new HashSet<Transaction>();
            UserAccountMappings = new HashSet<UserAccountMapping>();
        }

        public int AccountId { get; set; }
        public string? AccountHolderName { get; set; }
        public int? AccountType { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Balance> Balances { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UserAccountMapping> UserAccountMappings { get; set; }
    }
}
