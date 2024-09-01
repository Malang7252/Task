using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.Dtos.Login;
using Task.Service.Dtos.Register;
using Task.Service.Helper;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
namespace Task.Service.Services.Authentications
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Register(RegisterDto registerDto)
        {
            var user = new IdentityUser
            { 
                UserName = registerDto.UserName,
                Email = registerDto.UserName
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                if (registerDto.Roles != null && registerDto.Roles.Any())
                {
                    foreach (var role in registerDto.Roles)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, role);

                        if (!roleResult.Succeeded)
                        {
                            return ServiceResponse<string>.ReturnFailed(400, "Failed to add roles to the user.");
                        }
                    }
                }

                return ServiceResponse<string>.ReturnResultWith200("User was registered successfully! Please log in.");
            }

            return ServiceResponse<string>.ReturnFailed(400, "Something went wrong.");
        }

        public async Task<ServiceResponse<string>> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.UserName);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null && roles.Any())
                    {
                      
                        var jwtTokenResponse = CreateJwtToken(user, roles.ToList());
                        if (jwtTokenResponse.Success)
                        {
                            var response = new LoginResponseDto
                            {
                                JwtToken = jwtTokenResponse.Data
                            };
                            return ServiceResponse<string>.ReturnResultWith200(response.JwtToken);
                        }
                        else
                        {
                            return ServiceResponse<string>.ReturnFailed(500, "Failed to generate JWT token.");
                        }
                    }

                    return ServiceResponse<string>.ReturnResultWith200("Login successful, but user has no assigned roles.");
                }
            }

            return ServiceResponse<string>.ReturnFailed(401, "Username or password is incorrect.");
        }

        public ServiceResponse<string> CreateJwtToken(IdentityUser user, List<string> roles)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return ServiceResponse<string>.ReturnResultWith200(tokenString);
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.ReturnException(ex);
            }
        }

    }
}
