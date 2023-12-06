using Application.DTOs;
using Application.Interfaces.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
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
            _factionService = factionService ?? throw new NullReferenceException("FactionService cannot be null");
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route(nameof(GetAllFactions))]
        public ActionResult<List<Faction>> GetAllFactions()
        {
            try
            {
                var factionList = _factionService.GetAllFactions();
                return Ok(factionList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        [Route(nameof(GetFactionById))]
        public ActionResult<Faction> GetFactionById([FromBody] int id)
        {
            try
            {
                var factionReturn = _factionService.GetFactionById(id);
                return Ok(factionReturn);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize]
        [HttpPost]
        [Route(nameof(CreateFaction))]
        public ActionResult<Faction> CreateFaction([FromBody] FactionRequest factionRequest)
        {
            try
            {
                var factionReturn = _factionService.CreateFaction(factionRequest);
                return Ok(factionReturn);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize]
        [HttpPut]
        [Route(nameof(UpdateFaction))]
        public ActionResult<Faction> UpdateFaction([FromBody] Faction faction)
        {
            try
            {
                var factionReturn = _factionService.UpdateFaction(faction);
                return Ok(factionReturn);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteFaction))]
        public ActionResult DeleteFaction([FromBody] Faction faction)
        {
            try
            {
                _factionService.DeleteFaction(faction);
                return Ok("Faction deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
