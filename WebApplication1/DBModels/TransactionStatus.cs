using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class TransactionStatus
    {
        public TransactionStatus()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int TransactionStatusId { get; set; }
        public string? TransactionStatus1 { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
