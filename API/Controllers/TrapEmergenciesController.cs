using Core.DTOs;
using Core.DTOs.Trap.TrapEmergency;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "General")]
    [Area("General")]
    public class TrapEmergenciesController : ControllerBase
    {
        private readonly ITrapEmergencyService _trapEmergencyService;
        public TrapEmergenciesController(ITrapEmergencyService trapEmergencyService)
        {
            _trapEmergencyService = trapEmergencyService;
        }

        [HttpGet("GetAllTrapEmergencies")]
        public async Task<ActionResult<GlobalResponse>> GetAllTrapEmergenciesAsync(string serialNumber, int month, int year, bool EmergenciesGroupByYear)
        {
            var res = await _trapEmergencyService.GetAllTrapEmergenciesAsync(serialNumber, month, year, EmergenciesGroupByYear);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost("CreateTrapEmergency")]
        public async Task<ActionResult<SimpleResponse>> CreateTrapEmergencyAsync(EmergencyWrite emergencyWrite)
        {
            var res = await _trapEmergencyService.CreateTrapEmergencyAsync(emergencyWrite);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

    }
}
