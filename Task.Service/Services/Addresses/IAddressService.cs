using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Address;
using Task.Service.Helper;

namespace Task.Service.Services.Addresses
{
    public interface IAddressService
    {
        Task<ServiceResponse<AddressDto>> CreateAddressAsync(AddressDto addressDto);
        Task<ServiceResponse<AddressDto>> UpdateAddressAsync(AddressDto addressDto);
        Task<ServiceResponse<bool>> DeleteAddressAsync(Guid addressId);
        Task<ServiceResponse<AddressDto>> GetAddressByIdAsync(Guid addressId);
        Task<ServiceResponse<IEnumerable<AddressDto>>> GetAllAddressesAsync();
    }
}
