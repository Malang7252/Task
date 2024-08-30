using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Clients;
using Task.Models.Entities;
using Task.Service.Dtos.Client;
using Task.Service.Helper;

namespace Task.Service.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDto> GetClientWithDetailsAsync(Guid clientId)
        {
            var client = await _clientRepository.FindByInclude(
                c => c.Id == clientId,
                c => c.Addresses,
                c => c.Accounts
            ).FirstOrDefaultAsync();

            return _mapper.Map<ClientDto>(client);
        }

       public async Task<ServiceResponse<ClientDto>> CreateClientAsync(ClientDto clientDto)
        {
            try
            {
                var clientDomain = _mapper.Map<Client>(clientDto);

                _clientRepository.Add(clientDomain);
                await _clientRepository.SaveAsync();

                var resultDto = _mapper.Map<ClientDto>(clientDomain);
                return ServiceResponse<ClientDto>.ReturnResultWith201(resultDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ClientDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<ClientDto>> UpdateClientAsync(ClientDto clientDto)
        {
            try
            {
                var clientEntity = await _clientRepository.FindAsync(clientDto.Id);
                if (clientEntity == null)
                    return ServiceResponse<ClientDto>.Return404();

                _mapper.Map(clientDto, clientEntity);
                _clientRepository.Update(clientEntity);
                await _clientRepository.SaveAsync();

                var resultDto = _mapper.Map<ClientDto>(clientEntity);
                return ServiceResponse<ClientDto>.ReturnResultWith200(resultDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ClientDto>.ReturnException(ex);
            }
        }


        public async Task<ServiceResponse<bool>> DeleteClientAsync(Guid clientId)
        {
            try
            {
                var clientEntity = await _clientRepository.FindAsync(clientId);
                if (clientEntity == null)
                    return ServiceResponse<bool>.Return404();

                _clientRepository.Delete(clientId); ;
                await _clientRepository.SaveAsync();

                return ServiceResponse<bool>.ReturnResultWith204();
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.ReturnException(ex);
            }
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync()
        {
            // Get all entities, including related data if necessary
            var clients = await _clientRepository
                .AllIncluding(c => c.Addresses, c => c.Accounts)
                .ToListAsync();

            // Map the entities to DTOs and return them
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto?> GetClientByIdAsync(Guid clientId)
        {
            var client = await _clientRepository
                .FindByInclude(c => c.Id == clientId, c => c.Addresses, c => c.Accounts)
                .FirstOrDefaultAsync();

            if (client == null)
            {
                throw new Exception("Client not found");
            }

            //Domain Model to Dto
            return _mapper.Map<ClientDto>(client);
        }
    }
}
