using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class Balance
    {
        public int BalanceId { get; set; }
        public int AccountId { get; set; }
        public decimal? Balance1 { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
