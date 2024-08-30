using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Clients;
using Task.Data;
using Task.GenericRepository;
using Task.Models.Entities;

namespace Task.DAL.Repositories.Accounts
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
