using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data;
using Task.GenericRepository;
using Task.Models.Entities;

namespace Task.DAL.Repositories.Clients
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Client> All => DbSet; // Ensure this points to the correct DbSet


    }
}
