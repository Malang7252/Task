using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Service.Dtos.Address;
using Task.Service.Services.Addresses;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDto addressDto)
        {
            var response = await _addressService.CreateAddressAsync(addressDto);
            return ReturnFormattedResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequestDto requestDto)
        {
            var response = await _addressService.UpdateAddressAsync(requestDto);
            return ReturnFormattedResponse(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            var response = await _addressService.DeleteAddressAsync(id);
            return ReturnFormattedResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            var response = await _addressService.GetAddressByIdAsync(id);
            return ReturnFormattedResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var response = await _addressService.GetAllAddressesAsync();
            return ReturnFormattedResponse(response);
        }
    }
}
