using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Client;
using Task.Service.Helper;

namespace Task.Service.Services.Clients
{
    public interface IClientService
    {
        // Creates a new Client
        Task<ServiceResponse<ClientDto>> CreateClientAsync(ClientDto clientDto);

        // Updates an existing Client
        Task<ServiceResponse<ClientDto>> UpdateClientAsync(ClientDto clientDto);
        // Deletes a Client by ID
        Task<ServiceResponse<bool>> DeleteClientAsync(Guid clientId);

        // Retrieves a Client by ID
        Task<ClientDto?> GetClientByIdAsync(Guid clientId);

        // Retrieves all Clients
        Task<IEnumerable<ClientDto>> GetAllClientsAsync();

        // Retrieves a Client along with related Addresses and Accounts
        Task<ClientDto> GetClientWithDetailsAsync(Guid clientId);
    }
}
