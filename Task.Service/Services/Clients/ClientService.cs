using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache cache;

        public ClientService(IClientRepository clientRepository, IMapper mapper , IMemoryCache cache)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            this.cache = cache;
        }

        public async Task<ServiceResponse<ClientDto>> CreateClientAsync(ClientDto clientDto)
        {
            try
            {
                var clientDomain = _mapper.Map<Client>(clientDto);

                clientDomain.Id = Guid.NewGuid();

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

                _clientRepository.Remove(clientEntity); 
                await _clientRepository.SaveAsync();

                cache.Remove(GenerateCacheKey(null, null, null, true, 1, 1000));


                return ServiceResponse<bool>.ReturnResultWith204();
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.ReturnException(ex);
            }
        }


        public async Task<ServiceResponse<ClientDto>> GetClientByIdAsync(Guid clientId)
        {
            try
            {
                var clientEntity = await _clientRepository.FindAsync(clientId);
                if (clientEntity == null)
                    return ServiceResponse<ClientDto>.Return404();

                var clientDto = _mapper.Map<ClientDto>(clientEntity);
                return ServiceResponse<ClientDto>.ReturnResultWith200(clientDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ClientDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<IEnumerable<ClientDto>>> GetAllClientsAsync(
                string? filterOn = null, string? filterQuery = null,
                string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            try
            {
                var cacheKey = GenerateCacheKey(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

                if (cache.TryGetValue(cacheKey, out IEnumerable<ClientDto> cachedClients))
                {
                    return ServiceResponse<IEnumerable<ClientDto>>.ReturnResultWith200(cachedClients);
                }

                var clientQuery = _clientRepository.All
                    .Include(c => c.Addresses)
                    .AsQueryable();

                // Filtering
                if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
                {
                    if (filterOn.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                    {
                        clientQuery = clientQuery.Where(x => x.FirstName.ToLower().Contains(filterQuery.ToLower()));
                    }
                    else if (filterOn.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                    {
                        clientQuery = clientQuery.Where(x => x.LastName.ToLower().Contains(filterQuery.ToLower()));
                    }
                    else if (filterOn.Equals("Country", StringComparison.OrdinalIgnoreCase))
                    {
                        clientQuery = clientQuery.Where(x => x.Addresses.Any(a => a.Country.ToLower().Contains(filterQuery.ToLower())));
                    }
                    else if (filterOn.Equals("City", StringComparison.OrdinalIgnoreCase))
                    {
                        clientQuery = clientQuery.Where(x => x.Addresses.Any(a => a.City.ToLower().Contains(filterQuery.ToLower())));
                    }
                }

                // Sorting
                if (!string.IsNullOrWhiteSpace(sortBy))
                {
                    switch (sortBy.ToLower())
                    {
                        case "firstname":
                            clientQuery = isAscending ? clientQuery.OrderBy(x => x.FirstName) : clientQuery.OrderByDescending(x => x.FirstName);
                            break;
                        case "lastname":
                            clientQuery = isAscending ? clientQuery.OrderBy(x => x.LastName) : clientQuery.OrderByDescending(x => x.LastName);
                            break;
                        case "country":
                            clientQuery = isAscending ? clientQuery.OrderBy(x => x.Addresses.FirstOrDefault().Country) : clientQuery.OrderByDescending(x => x.Addresses.FirstOrDefault().Country);
                            break;
                        case "city":
                            clientQuery = isAscending ? clientQuery.OrderBy(x => x.Addresses.FirstOrDefault().City) : clientQuery.OrderByDescending(x => x.Addresses.FirstOrDefault().City);
                            break;
                        case "zipcode":
                            clientQuery = isAscending ? clientQuery.OrderBy(x => x.Addresses.FirstOrDefault().ZipCode) : clientQuery.OrderByDescending(x => x.Addresses.FirstOrDefault().ZipCode);
                            break;
                    }
                }

                // Pagination
                var skipResults = (pageNumber - 1) * pageSize;

                var clientEntities = await clientQuery.Skip(skipResults).Take(pageSize).ToListAsync();
                var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clientEntities);

                cache.Set(cacheKey, clientDtos, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) 
                });

                return ServiceResponse<IEnumerable<ClientDto>>.ReturnResultWith200(clientDtos);
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<ClientDto>>.ReturnException(ex);
            }
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

        private string GenerateCacheKey(string? filterOn, string? filterQuery, string? sortBy, bool isAscending, int pageNumber, int pageSize)
        {
            return $"ClientList_{filterOn}_{filterQuery}_{sortBy}_{isAscending}_{pageNumber}_{pageSize}";
        }


    }
}
