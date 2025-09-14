using AutoMapper;
using Core.DTOs;
using Core.DTOs.Company;
using Core.Entities;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GlobalResponse> GetById(int id)
        {
            Company company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            if (company == null)
                return new GlobalResponse { IsSuccess = false, Message = "Not Found!", StatusCode = HttpStatusCode.NotFound };
            CompanyReadDto companyReadDto = _mapper.Map<CompanyReadDto>(company);

            return new GlobalResponse<CompanyReadDto> { StatusCode = HttpStatusCode.OK, Message = "Company retrieved!", IsSuccess = true, Data = companyReadDto };
        }

        public async Task<GlobalResponse<CompanyReadDto>> CreateCompany(CompanyCreateDto dto)
        {
            Company company = _mapper.Map<Company>(dto);
            company = await _unitOfWork.CompanyRepository.AddAsync(company);

            if (await _unitOfWork.SaveChangesAsync())
            {
                CompanyReadDto companyReadDto = _mapper.Map<CompanyReadDto>(company);
                return new GlobalResponse<CompanyReadDto> { IsSuccess = true, Message = "Created!", StatusCode = HttpStatusCode.OK,Data = companyReadDto };
            }

            return new GlobalResponse<CompanyReadDto> { IsSuccess = false, Message = "Faild to create!", StatusCode = HttpStatusCode.BadRequest };
        }
    }
}
