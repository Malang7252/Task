using Microsoft.AspNetCore.Mvc;
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
        Task<ServiceResponse<ClientDto>> CreateClientAsync(ClientDto clientDto);

        Task<ServiceResponse<ClientDto>> UpdateClientAsync(ClientDto clientDto);

        Task<ServiceResponse<bool>> DeleteClientAsync(Guid clientId);

        Task<ServiceResponse<ClientDto>> GetClientByIdAsync(Guid clientId);

        Task<ServiceResponse<IEnumerable<ClientDto>>> GetAllClientsAsync(string? filterOn = null , string? filterQuery = null, 
            string? sortBy = null,  bool IsAscending = true , int pageNumber = 1 , int pageSize = 1000 );

        Task<ClientDto> GetClientWithDetailsAsync(Guid clientId);
    }
}
