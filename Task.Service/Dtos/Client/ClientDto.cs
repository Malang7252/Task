using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Accounts;
using Task.Service.Dtos.Address;

namespace Task.Service.Dtos.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string ProfilePhoto { get; set; }
        public string MobileNumber { get; set; }
        public string Sex { get; set; }
        public List<AddressDto> Addresses { get; set; } // Include related addresses
        public List<AccountDto> Accounts { get; set; } // Include related accounts
    }
}

