using Core.Constants;
using Core.DTOs;
using Core.DTOs.Trap.Statistic;
using Core.DTOs.Trap.TrapRead;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "General")]
    [Area("General")]
    public class TrapReadController : ControllerBase
    {
        private readonly ITrapReadService _trapReadService;
        public TrapReadController(ITrapReadService trapReadService)
        {
            _trapReadService = trapReadService;
        }

        [HttpPost("CreateTrapReading")]
        [AllowAnonymous]
        public async Task<ActionResult<GlobalResponse>> CreateTrapReading(ReadDetailsCreateDto dto)
        {
            var res = await _trapReadService.CreateTrapReading(dto);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetAllTrapReadings")]
        [Authorize(Roles = $"{RoleName.Superadmin},{RoleName.SuperVisor},{RoleName.User}")]
        public async Task<ActionResult<GlobalResponse>> GetAllTrapReadingsAsync([FromQuery] ReadRequestDto model)
        {
            var res = await _trapReadService.GetAllTrapReadingsAsync(model);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }


        [HttpGet("GetStatisticsOfTrapsOnlyCurrentUser")]
        [Authorize]
        public async Task<ActionResult<GlobalResponse<StatisticsDto>>> GetStatisticsOfTrapsOnlyCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new GlobalResponse<StatisticsDto> { IsSuccess = false, Message = "User not authenticated", StatusCode = System.Net.HttpStatusCode.Unauthorized });
            }

            var result = await _trapReadService.GetUserTrapStatistics(Guid.Parse(userId));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
