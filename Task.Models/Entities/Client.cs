using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string ProfilePhoto { get; set; } // URL or base64 string
        public string MobileNumber { get; set; }
        public string Sex { get; set; } // "Male" or "Female"

        public ICollection<Address> Addresses { get; set; } // Client can have multiple addresses
        public ICollection<Account> Accounts { get; set; } // Navigation property for Accounts
    }
}
