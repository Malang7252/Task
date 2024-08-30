using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Accounts;
using Task.Service.Helper;

namespace Task.Service.Services.Accounts
{
    public interface IAccountService
    {
        Task<ServiceResponse<AccountDto>> CreateAccountAsync(AccountDto accountDto);
        Task<ServiceResponse<AccountDto>> UpdateAccountAsync(AccountDto accountDto);
        Task<ServiceResponse<bool>> DeleteAccountAsync(Guid accountId);
        Task<ServiceResponse<AccountDto>> GetAccountByIdAsync(Guid accountId);
        Task<ServiceResponse<IEnumerable<AccountDto>>> GetAllAccountsAsync();
    }
}
