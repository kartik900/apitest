using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string? AccountHolderName { get; set; }
        public int? AccountType { get; set; }
    }
}
