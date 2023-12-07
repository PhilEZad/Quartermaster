using Application.DTOs;
using Application.DTOs.Responses;
using Application.DTOs.Updates;
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
        public ActionResult<List<FactionResponse>> GetAllFactions()
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
        
        [AllowAnonymous]
        [HttpGet]
        [Route(nameof(GetFactionById) + "/{id}")]
        public ActionResult<FactionResponse> GetFactionById([FromRoute] int id)
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
        public ActionResult<FactionResponse> CreateFaction([FromBody] Application.DTOs.Requests.FactionRequest factionRequest)
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
        public ActionResult<FactionResponse> UpdateFaction([FromBody] FactionUpdate update)
        {
            try
            {
                var updatedFaction = _factionService.UpdateFaction(update);
                return Ok(updatedFaction);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteFaction) + "/{id})")]
        public ActionResult DeleteFaction([FromRoute] int id)
        {
            try
            {
                _factionService.DeleteFaction(id);
                return Ok("Faction deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
