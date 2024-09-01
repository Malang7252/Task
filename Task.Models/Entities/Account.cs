using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models.Entities
{
    public class Account : BaseModel
    {
        public Guid Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public Guid ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
    }
}
