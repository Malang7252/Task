using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.GenericRepository;
using Task.Models.Entities;

namespace Task.DAL.Repositories.Clients
{
    public interface IClientRepository :IGenericRepository<Client>
    {
    }
}
