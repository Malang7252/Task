using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Login;
using Task.Service.Dtos.Register;
using Task.Service.Helper;

namespace Task.Service.Services.Authentications
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Register(RegisterDto registerDto);

        Task<ServiceResponse<string>> Login(LoginDto loginDto);

        ServiceResponse<string> CreateJwtToken(IdentityUser user, List<string> roles);

    }
}
