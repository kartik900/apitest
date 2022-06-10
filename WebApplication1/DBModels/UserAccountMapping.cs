using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class UserAccountMapping
    {
        public int UserAccountMappingId { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
