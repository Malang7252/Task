using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public Guid ClientId { get; set; } // Foreign key for Client
        public Client Client { get; set; } // Navigation property for Client
    }
}
