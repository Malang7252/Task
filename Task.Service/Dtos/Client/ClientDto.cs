using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(30, ErrorMessage = "First name can't be longer than 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(30, ErrorMessage = "Last name can't be longer than 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Personal ID is required.")]
        [StringLength(11, ErrorMessage = "Personal ID must be exactly 11 characters.")]

        public string PersonalId { get; set; }

        public string? ProfilePhoto { get; set; } 

        [Required(ErrorMessage = "Mobile number is required.")]
        [StringLength(11, ErrorMessage = "MobileNumber must be exactly 11 characters.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Sex is required.")]
        [RegularExpression("Male|Female", ErrorMessage = "Sex must be either 'Male' or 'Female'.")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public ICollection<AddressDto> Addresses { get; set; }

        [Required(ErrorMessage = "At least one account is required.")]
        public ICollection<AccountDto> Accounts { get; set; } 
    }
}

