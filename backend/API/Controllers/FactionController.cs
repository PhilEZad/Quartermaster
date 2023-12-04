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
            _factionService = factionService;
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(GetAllFactions))]
        public ActionResult<Faction[]> GetAllFactions()
        {
            try
            {
                Faction[] factionList = _factionService.GetAllFactions();
                Ok(factionList);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }

        [Authorize]
        [HttpGet]
        [Route(nameof(GetFactionById))]
        {
            try
            {
                Faction faction = _factionService.GetFactionById(id);
                Ok(faction);
            } catch (Exception e)
            {
                BadRequest(e);
            }
        }
        
        [Authorize]
        [HttpPost]
        [Route(nameof(CreateFaction))]
        public ActionResult<Faction> CreateFaction(Faction faction)
        {
            try
            {
                Faction faction = _factionService.CreateFaction(faction);
                Ok(faction);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }
        
        [Authorize]
        [HttpPut]
        [Route(nameof(UpdateFaction))]
        public ActionResult<Faction> UpdateFaction(Faction faction)
        {
            try
            {
                Faction faction = _factionService.UpdateFaction(faction);
                Ok(faction);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }
        
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteFaction))]
        public ActionResult<Boolean> DeleteFaction(int id)
        {
            try
            {
                Boolean faction = _factionService.DeleteFaction(id);
                Ok(faction);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }
    }
}
