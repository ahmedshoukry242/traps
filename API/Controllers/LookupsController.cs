using Core.DTOs;
using Core.DTOs.Lookups;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "General")]
    [Area("General")]
    public class LookupsController : ControllerBase
    {
        private readonly ILookupsService _lookupsService;
        public LookupsController(ILookupsService lookupsService)
        {
            _lookupsService = lookupsService;
        }

        [HttpGet("GetAllCountries")]
        public async Task<ActionResult<GlobalResponse>> GetAllCountries()
        {
            var res = await _lookupsService.GetAllCountries();
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetAllStates/{countryId}")]
        public async Task<ActionResult<GlobalResponse>> GetAllStates(int countryId)
        {
            var res = await _lookupsService.GetAllStates(countryId);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<GlobalResponse>> GetAllCategories()
        {
            var res = await _lookupsService.GetAllCategories();
            if(!res.IsSuccess)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<GlobalResponse>> CreateCategory([FromBody] LookupsReadDto dto)
        {
            var res = await _lookupsService.CreateCategory(dto.Name);
            if (!res.IsSuccess)
                return BadRequest(res);
            return Created();
        }
        [HttpPut("UpdateCategory/{id}")]
        public async Task<ActionResult<GlobalResponse>> UpdateCategory(int id, [FromBody] LookupsReadDto dto)
        {
            var res = await _lookupsService.UpdateCategory(id,dto.Name);
            if (!res.IsSuccess)
            {
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return NotFound(res);

                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<ActionResult<GlobalResponse>> DeleteCategory(int id)
        {
            var res = await _lookupsService.DeleteCategory(id);
            if (!res.IsSuccess)
            {
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return NotFound(res);

                return BadRequest(res);
            }
            return Ok(res);
        }

    }
}
