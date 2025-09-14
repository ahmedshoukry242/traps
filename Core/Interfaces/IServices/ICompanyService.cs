using Core.DTOs;
using Core.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices
{
    public interface ICompanyService
    {
        Task<GlobalResponse> GetById(int id);
        Task<GlobalResponse<CompanyReadDto>> CreateCompany(CompanyCreateDto dto);
    }
}
