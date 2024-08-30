using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Accounts;

namespace Task.Service.Services.Accounts
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccountAsync(AccountDto accountDto);
        Task<AccountDto> UpdateAccountAsync(AccountDto accountDto);
        Task<bool> DeleteAccountAsync(Guid accountId);
        Task<AccountDto> GetAccountByIdAsync(Guid accountId);
        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
    }
}
