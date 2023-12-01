
using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtProvider _jwtProvider;
        
        public AuthController(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Login))]
        public ActionResult<string> Login(LoginRequest dto)
        {
            var token = _jwtProvider.GenerateToken(dto.Username, dto.Password);

            return token;
        }
    }
}
