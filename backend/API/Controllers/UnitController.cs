using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService ?? throw new NullReferenceException("UnitService cannot be null");
        }
        
        [Authorize]
        [HttpPost]
        [Route(nameof(CreateUnit))]
        public IActionResult CreateUnit(UnitRequest unitRequest)
        {
            try
            {
                var unit = _unitService.CreateUnit(unitRequest);
                return Ok(unit);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // GET: api/Unit/GetAllUnits
        [HttpGet]
        [Route(nameof(GetAllUnits))]
        public IActionResult GetAllUnits()
        {
            try
            {
                var units = _unitService.GetAllUnits();
                return Ok(units);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // GET: api/Unit/GetUnitById/5
        [HttpGet]
        [Route(nameof(GetUnitById) + "/{id}")]
        public IActionResult GetUnitById(int id)
        {
            try
            {
                var unit = _unitService.GetUnitById(id);
                return Ok(unit);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // PUT: api/Unit/UpdateUnit
        [Authorize]
        [HttpPut]
        [Route(nameof(UpdateUnit))]
        public IActionResult UpdateUnit(Unit unit)
        {
            try
            {
                var updatedUnit = _unitService.UpdateUnit(unit);
                return Ok(updatedUnit);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // DELETE: api/Unit/DeleteUnit
        [Authorize]
        [HttpDelete]
        [Route(nameof(DeleteUnit))]
        public IActionResult DeleteUnit(Unit unit)
        {
            try
            {
                var deletedUnit = _unitService.DeleteUnit(unit);
                return Ok(deletedUnit);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
