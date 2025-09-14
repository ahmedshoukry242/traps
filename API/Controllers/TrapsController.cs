using Core.DTOs;
using Core.DTOs.Trap;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "General")]
    [Area("General")]
    public class TrapsController : ControllerBase
    {
        private readonly ITrapService _trapService;
        public TrapsController(ITrapService trapService)
        {
            _trapService = trapService;
        }


        [HttpPost("CreatTrap")]
        [AllowAnonymous]
        public async Task<ActionResult<GlobalResponse>> AddTrap(TrapCreateDto dto)
        {
            var result = await _trapService.AddTrap(dto);

            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("LoadConfigurations/{Serial}")]
        public async Task<ActionResult> TrapConfigurations(/*ConfogurationsReadDto dto*/ string Serial)
        {
            var res = await _trapService.TrapConfigurations(Serial);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res.Data);
        }

        #region Getting Traps Data
        [HttpGet("ListOfTraps")]
        public async Task<ActionResult<GlobalResponse>> ListOfTrapsAsync([FromQuery] TrapFilters.TrapFilter filter)
        {
            var res = await _trapService.ListOfTrapsAsync(filter);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetAllTraps")]
        public async Task<ActionResult<GlobalResponse>> GetAllTrapsAsync([FromQuery]TrapFilters.trapAllFilter filter)
        {
            var res = await _trapService.GetAllTrapsAsync(filter);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }
        #endregion
    }
}
