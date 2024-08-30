using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models.Entities;
using Task.Service.Dtos.Accounts;
using Task.Service.Dtos.Address;
using Task.Service.Dtos.Client;

namespace Task.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>()
                  .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                  .ForMember(dest => dest.Accounts, opt => opt.MapFrom(src => src.Accounts));



            CreateMap<Address, AddressDto>();
            CreateMap<Account, AccountDto>();

            CreateMap<ClientDto, Client>();
            CreateMap<AddressDto, Address>();
            CreateMap<AccountDto, Account>();
        }
    }
}
