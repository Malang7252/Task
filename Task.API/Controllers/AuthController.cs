using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Service.Dtos.Login;
using Task.Service.Dtos.Register;
using Task.Service.Services.Authentications;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.Register(registerDto);
            return ReturnFormattedResponse(response);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            return ReturnFormattedResponse(result);
        }
    }
}
