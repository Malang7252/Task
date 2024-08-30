using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Accounts;
using Task.Data;
using Task.GenericRepository;
using Task.Models.Entities;

namespace Task.DAL.Repositories.Addresses
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
