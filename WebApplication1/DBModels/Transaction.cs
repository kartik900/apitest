using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public string TransactionFlow { get; set; } = null!;
        public decimal? Amount { get; set; }
        public string TransactionMode { get; set; } = null!;
        public int? TransactionStatusId { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual TransactionStatus? TransactionStatus { get; set; }
    }
}
