using Core.DTOs;
using Core.DTOs.Company;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName ="General")]
    [Area("General")]
    [AllowAnonymous]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<ActionResult<GlobalResponse>> CreateCompany([FromBody] CompanyCreateDto dto)
        {
            var res = await _companyService.CreateCompany(dto);
            if (!res.IsSuccess)
                return BadRequest(res);
            return CreatedAtAction(nameof(GetById), new { id = res.Data.Id }, res.Data);
        }

        [HttpGet("{id}",Name = "GetById")]
        public async Task<ActionResult<GlobalResponse>> GetById(int id)
        {
            var res = await _companyService.GetById(id);
            if (!res.IsSuccess) return NotFound(res);
            return Ok(res);
        }
    }
}
