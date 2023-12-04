using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactionController : ControllerBase
    {
        private readonly IFactionService _factionService;

        public FactionController(IFactionService factionService)
        {
            _factionService = factionService ?? throw new NullReferenceException();
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(GetAllFactions))]
        public ActionResult<Faction[]> GetAllFactions()
        {
            try
            {
                Faction[] factionList = _factionService.GetAllFactions();
                return Ok(factionList);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(GetFactionById))]
        public ActionResult<Faction> GetFactionById([FromBody] int id)
        {
            try
            {
                Faction faction = _factionService.GetFactionById(id);
                return Ok(faction);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [Authorize]
        [HttpPost]
        [Route(nameof(CreateFaction))]
        public ActionResult<Faction> CreateFaction([FromBody] Faction faction)
        {
            try
            {
                Faction factionReturn = _factionService.CreateFaction(faction);
                return Ok(faction);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [Authorize]
        [HttpPut]
        [Route(nameof(UpdateFaction))]
        public ActionResult<Faction> UpdateFaction([FromBody] Faction faction)
        {
            try
            {
                Faction factionReturn = _factionService.UpdateFaction(faction);
                return Ok(factionReturn);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteFaction))]
        public ActionResult<Boolean> DeleteFaction([FromBody] Faction faction)
        {
            try
            {
                Boolean response = _factionService.DeleteFaction(faction);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
