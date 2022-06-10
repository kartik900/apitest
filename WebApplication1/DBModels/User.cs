using System;
using System.Collections.Generic;

namespace WebApplication1.DBModels
{
    public partial class User
    {
        public User()
        {
            UserAccountMappings = new HashSet<UserAccountMapping>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressPinCode { get; set; }

        public virtual ICollection<UserAccountMapping> UserAccountMappings { get; set; }
    }
}
