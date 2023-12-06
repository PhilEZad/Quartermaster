using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Responses;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService ?? throw new NullReferenceException("WeaponService cannot be null");
        }
        
        [Authorize]
        [HttpPost]
        [Route(nameof(CreateWeapon))]
        public IActionResult CreateWeapon([FromBody] WeaponRequest weaponRequest)
        {
            try
            {
                var response = _weaponService.CreateWeapon(weaponRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route(nameof(GetAllWeapons))]
        public IActionResult GetAllWeapons()
        {
            try
            {
                var response = _weaponService.GetAllWeapons();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route(nameof(GetWeaponById))]
        public IActionResult GetWeaponById(int id)
        {
            try
            {
                var response = _weaponService.GetWeaponById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route(nameof(GetWeaponByModelId))]
        public IActionResult GetWeaponByModelId(int id)
        {
            try
            {
                var response = _weaponService.GetWeaponByModelId(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route(nameof(GetWeaponByFactionId))]
        public IActionResult GetWeaponByFactionId(int id)
        {
            try
            {
                var response = _weaponService.GetWeaponByFactionId(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize]
        [HttpPut]
        [Route(nameof(UpdateWeapon))]
        public IActionResult UpdateWeapon([FromBody] WeaponRequest weaponRequest)
        {
            try
            {
                var response = _weaponService.UpdateWeapon(weaponRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteWeapon))]
        public IActionResult DeleteWeapon([FromBody] WeaponRequest weaponRequest)
        {
            try
            {
                var response = _weaponService.DeleteWeapon(weaponRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
