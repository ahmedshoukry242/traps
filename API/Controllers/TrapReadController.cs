using Azure;
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
        
        [HttpGet("GetAllTrapReadingsPerDay")]
        [Authorize(Roles = $"{RoleName.Superadmin},{RoleName.SuperVisor},{RoleName.User}")]
        public async Task<ActionResult<GlobalResponse>> GetAllTrapReadingsPerDayAsync([FromQuery]ReadRequestDto model)
        {
            var res = await _trapReadService.GetAllTrapReadingsPerDayAsync(model);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetAllTrapReadsChart")]
        public async Task<ActionResult<GlobalResponse>> GetAllTrapReadsChart([FromQuery]ReadRequestChartDto model)
        {
            var res = await _trapReadService.GetAllTrapReadsChart(model);
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

        [Authorize(Roles = $"{RoleName.Superadmin},{RoleName.User},{RoleName.UserChild},{RoleName.SuperVisor}")]
        [HttpGet("GetTrapsLastRead")]
        public async Task<ActionResult<GlobalResponse>> GetLastReadingToCurrentUserTrapsAsync(Guid? userId,int? trapId)
        {
            var validateUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(validateUserId))
            {
                return Unauthorized(new GlobalResponse<StatisticsDto> { IsSuccess = false, Message = "User not authenticated", StatusCode = System.Net.HttpStatusCode.Unauthorized });
            }
            var result = await _trapReadService.GetTrapsLastRead(userId,trapId);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpGet("GetStatisticsForAllTrapsReadingsAsInsects")]
        public async Task<ActionResult<GlobalResponse>> GetStatisticsForTrapReadingsAsInsectsAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new GlobalResponse<StatisticsDto> { IsSuccess = false, Message = "User not authenticated", StatusCode = System.Net.HttpStatusCode.Unauthorized });
            }
            var result = await _trapReadService.GetStatisticsForTrapReadingsAsInsectsAsync();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetCountOfMosuqitoesPerSevenDays")]
        public async Task<ActionResult<GlobalResponse>> GetCountOfMosuqitoesToLastSixDaysAsync(bool isMosquitoe)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new GlobalResponse<StatisticsDto> { IsSuccess = false, Message = "User not authenticated", StatusCode = System.Net.HttpStatusCode.Unauthorized });
            }
            var result = await _trapReadService.GetCountOfMosuqitoesToLastSixDaysAsync(isMosquitoe);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        #region New
        [HttpGet("GetCountOfMosuqitoesToLast12Months")]
        [Authorize]
        public async Task<ActionResult<MonthlyMosquitoCountResponseDto>> GetCountOfMosuqitoesToLast12Months()
        {
            var result = await _trapReadService.GetCountOfMosuqitoesToLast12Months();
            if (!result.isSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("GetCountOfMosuqitoesPer6Month")]
        [Authorize]
        public async Task<ActionResult<GlobalResponse<List<MonthlyMosquitoCountPer6MonthDto>>>> GetCountOfMosuqitoesPer6Month()
        {

            var result = await _trapReadService.GetCountOfMosuqitoesPer6Month();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

        #endregion





    }
}
