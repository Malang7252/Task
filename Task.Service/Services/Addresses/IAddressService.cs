using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Address;

namespace Task.Service.Services.Addresses
{
    public interface IAddressService
    {
        Task<AddressDto> CreateAddressAsync(AddressDto addressDto);
        Task<AddressDto> UpdateAddressAsync(AddressDto addressDto);
        Task<bool> DeleteAddressAsync(Guid addressId);
        Task<AddressDto> GetAddressByIdAsync(Guid addressId);
        Task<IEnumerable<AddressDto>> GetAllAddressesAsync();
    }
}
