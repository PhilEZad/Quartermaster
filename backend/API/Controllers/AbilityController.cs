using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbilityController : ControllerBase
    {
        private readonly IAbilityService _abilityService;
        
        public AbilityController(IAbilityService abilityService)
        {
            _abilityService = abilityService ?? throw new NullReferenceException("AbilityService cannot be null");
        }
        
        /*
         * Create
         */
        
        // POST: api/Weapon/CreateAbility>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route(nameof(CreateAbility))]
        public ActionResult<AbilityResponse> CreateAbility([FromBody] AbilityRequest abilityRequest)
        {
            try
            {
                var response = _abilityService.CreateAbility(abilityRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        /*
         * Read
         */
        
        // GET: api/Weapon/GetAllAbilities
        [HttpGet]
        [Route(nameof(GetAllAbilities))]
        public ActionResult GetAllAbilities()
        {
            try
            {
                var response = _abilityService.GetAllAbilities();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // GET: api/Weapon/GetAbilityById
        [HttpGet]
        [Route(nameof(GetAbilityById))]
        public ActionResult GetAbilityById(int id)
        {
            try
            {
                var response = _abilityService.GetAbilityById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        /*
         * Update
         */
        
        // PUT: api/Weapon/UpdateAbility
        [Authorize]
        [HttpPut]
        [Route(nameof(UpdateAbility))]
        public ActionResult UpdateAbility([FromBody] AbilityRequest abilityRequest)
        {
            try
            {
                var response = _abilityService.UpdateAbility(abilityRequest);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        /*
         * Delete
         */
        
        // DELETE: api/Weapon/GetDeleteAbility
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteAbility))]
        public ActionResult DeleteAbility(int id)
        {
            try
            {
                var response = _abilityService.DeleteAbility(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
