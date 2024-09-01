using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Service.Dtos.Accounts
{
    public class AccountDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        public string AccountNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive value.")]
        public decimal? Balance { get; set; }
        public Guid ClientId { get; set; }
    }
}
