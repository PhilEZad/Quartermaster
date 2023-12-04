
using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
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
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Login))]
        public ActionResult<LoginResponse> Login(LoginRequest dto)
        {
            try
            {
                var response = _authenticationService.Login(dto);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }
        }
        
        [Authorize]
        [HttpPost]
        [Route(nameof(Boop))]
        public ActionResult<string> Boop()
        {
            return "Boop";
        }
    }
}
