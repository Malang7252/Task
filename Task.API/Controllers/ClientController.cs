using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Service.Dtos.Client;
using Task.Service.Services.Clients;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateClient([FromBody] ClientDto clientDto)
        {
            var response = await _clientService.CreateClientAsync(clientDto);
            return ReturnFormattedResponse(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientDto clientDto)
        {
            var response = await _clientService.UpdateClientAsync(clientDto);
            return ReturnFormattedResponse(response);
        }

        [HttpDelete]
        [Route("Delete/{clientId:guid}")]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var response = await _clientService.DeleteClientAsync(clientId);
            return ReturnFormattedResponse(response);
        }

        [HttpGet]
        [Route("GetById/{clientId:guid}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetClientById(Guid clientId)
        {
            var response = await _clientService.GetClientByIdAsync(clientId);
            return ReturnFormattedResponse(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Admin")]

        // GET : /api/Client?filterOn=FirstName&filterQuery=Nouman&sortBy=FirstName&IsAscending=true&pageNumber=1&pagesize=10
        public async Task<IActionResult> GetAllClients([FromQuery] string? filterOn, [FromQuery] string? filterQuery ,
        [FromQuery] string? sortBy, [FromQuery] bool? IsAscending ,
        [FromQuery] int pageNumber = 1 , [FromQuery] int pageSize = 1000)
        {
            // Call service to get clients based on filters
            var response = await _clientService.GetAllClientsAsync(filterOn, filterQuery , sortBy , IsAscending ?? true , pageNumber , pageSize);

            // Return formatted response
            return ReturnFormattedResponse(response);
        }


        [HttpGet]
        [Route("GetWithDetails/{clientId:guid}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetClientWithDetails(Guid clientId)
        {
            var clientDto = await _clientService.GetClientWithDetailsAsync(clientId);
            return Ok(clientDto);
        }

    }
}
