using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Addresses;
using Task.Models.Entities;
using Task.Service.Dtos.Address;
using Task.Service.Helper;
using Microsoft.EntityFrameworkCore;


namespace Task.Service.Services.Addresses
{
    public class AddressService : IAddressService
    {

        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AddressDto>> CreateAddressAsync(AddressDto addressDto)
        {
            try
            {
                var addressEntity = _mapper.Map<Address>(addressDto);
                _addressRepository.Add(addressEntity);
                await _addressRepository.SaveAsync();

                var createdAddressDto = _mapper.Map<AddressDto>(addressEntity);
                return ServiceResponse<AddressDto>.ReturnResultWith201(createdAddressDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AddressDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<AddressDto>> UpdateAddressAsync(AddressDto addressDto)
        {
            try
            {
                var addressEntity = await _addressRepository.FindAsync(addressDto.Id);
                if (addressEntity == null)
                    return ServiceResponse<AddressDto>.Return404();

                _mapper.Map(addressDto, addressEntity);
                _addressRepository.Update(addressEntity);
                await _addressRepository.SaveAsync();

                var updatedAddressDto = _mapper.Map<AddressDto>(addressEntity);
                return ServiceResponse<AddressDto>.ReturnResultWith200(updatedAddressDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AddressDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<bool>> DeleteAddressAsync(Guid addressId)
        {
            try
            {
                var addressEntity = await _addressRepository.FindAsync(addressId);
                if (addressEntity == null)
                    return ServiceResponse<bool>.Return404("Address not found");

                _addressRepository.Remove(addressEntity);
                await _addressRepository.SaveAsync();

                return ServiceResponse<bool>.ReturnResultWith204();
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<AddressDto>> GetAddressByIdAsync(Guid addressId)
        {
            try
            {
                var addressEntity = await _addressRepository.FindAsync(addressId);
                if (addressEntity == null)
                    return ServiceResponse<AddressDto>.Return404();

                var addressDto = _mapper.Map<AddressDto>(addressEntity);
                return ServiceResponse<AddressDto>.ReturnResultWith200(addressDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AddressDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<IEnumerable<AddressDto>>> GetAllAddressesAsync()
        {
            try
            {
                var addressEntities = await _addressRepository.All.ToListAsync();
                var addressDtos = _mapper.Map<IEnumerable<AddressDto>>(addressEntities);
                return ServiceResponse<IEnumerable<AddressDto>>.ReturnResultWith200(addressDtos);
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<AddressDto>>.ReturnException(ex);
            }
        }
    }
}
