using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Repositories.Accounts;
using Task.Models.Entities;
using Task.Service.Dtos.Accounts;
using Task.Service.Helper;
using Microsoft.EntityFrameworkCore;

namespace Task.Service.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AccountDto>> CreateAccountAsync(AccountDto accountDto)
        {
            try
            {
                var accountEntity = _mapper.Map<Account>(accountDto);
                _accountRepository.Add(accountEntity);
                await _accountRepository.SaveAsync();

                var createdAccountDto = _mapper.Map<AccountDto>(accountEntity);
                return ServiceResponse<AccountDto>.ReturnResultWith201(createdAccountDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AccountDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<UpdateAccountRequestDto>> UpdateAccountAsync(UpdateAccountRequestDto requestDto)
        {
            try
            {
                var accountEntity = await _accountRepository.FindAsync(requestDto.Id);
                if (accountEntity == null)
                    return ServiceResponse<UpdateAccountRequestDto>.Return404();

                _mapper.Map(requestDto, accountEntity);
                _accountRepository.Update(accountEntity);
                await _accountRepository.SaveAsync();

                var updatedAccountDto = _mapper.Map<UpdateAccountRequestDto>(accountEntity);
                return ServiceResponse<UpdateAccountRequestDto>.ReturnResultWith200(updatedAccountDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<UpdateAccountRequestDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<bool>> DeleteAccountAsync(Guid accountId)
        {
            try
            {
                var accountEntity = await _accountRepository.FindAsync(accountId);
                if (accountEntity == null)
                    return ServiceResponse<bool>.Return404("Account not found");

                _accountRepository.Remove(accountEntity);
                await _accountRepository.SaveAsync();

                return ServiceResponse<bool>.ReturnResultWith204();
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<AccountDto>> GetAccountByIdAsync(Guid accountId)
        {
            try
            {
                var accountEntity = await _accountRepository.FindAsync(accountId);
                if (accountEntity == null)
                    return ServiceResponse<AccountDto>.Return404();

                var accountDto = _mapper.Map<AccountDto>(accountEntity);
                return ServiceResponse<AccountDto>.ReturnResultWith200(accountDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AccountDto>.ReturnException(ex);
            }
        }

        public async Task<ServiceResponse<IEnumerable<AccountDto>>> GetAllAccountsAsync()
        {
            try
            {
                var accountEntities = await _accountRepository.All.ToListAsync();
                var accountDtos = _mapper.Map<IEnumerable<AccountDto>>(accountEntities);
                return ServiceResponse<IEnumerable<AccountDto>>.ReturnResultWith200(accountDtos);
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<AccountDto>>.ReturnException(ex);
            }
        }
    }
}
