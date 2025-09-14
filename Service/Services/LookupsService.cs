using Core.DTOs;
using Core.DTOs.Lookups;
using Core.Entities.Lookups;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LookupsService : ILookupsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LookupsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GlobalResponse> GetAllCountries()
        {
            var res = await _unitOfWork.CountryRepository.GetAllQueryableAsNoTracking()
                .Select(x => new LookupsReadDto { Id = x.Id, Name = x.Name }).ToListAsync();

            return new GlobalResponse<List<LookupsReadDto>> { Data = res, IsSuccess = true, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> GetAllStates(int countryId)
        {
            var res = await _unitOfWork.StateRepository.GetAllQueryableAsNoTracking()
                .Where(x => x.CountryId == countryId)
                .Select(x => new LookupsReadDto { Id = x.Id, Name = x.Name }).ToListAsync();

            return new GlobalResponse<List<LookupsReadDto>> { Data = res, IsSuccess = true, StatusCode = System.Net.HttpStatusCode.OK };
        }


        #region Category
        public async Task<GlobalResponse> GetAllCategories()
        {
            var res = await _unitOfWork.CategoryRepository.GetAllQueryableAsNoTracking()
                .Select(x => new LookupsReadDto { Id = x.Id, Name = x.Name }).ToListAsync();

            return new GlobalResponse<List<LookupsReadDto>> { Data = res, IsSuccess = true, StatusCode = System.Net.HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> CreateCategory(string name)
        {
            Category category = new Category { Name = name };
            category = await _unitOfWork.CategoryRepository.AddAsync(category);
            if (!await _unitOfWork.SaveChangesAsync())
                return new GlobalResponse { IsSuccess = false, Message = "Couldn't create the category!", StatusCode = System.Net.HttpStatusCode.BadRequest };
            return new GlobalResponse { IsSuccess = true, StatusCode = System.Net.HttpStatusCode.Created, Message = "Created!" };
        }

        public async Task<GlobalResponse> UpdateCategory(int id, string name)
        {
            Category category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
                return new GlobalResponse { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.NotFound };
            category.Name = name;

            _unitOfWork.CategoryRepository.Update(category);
            if (!await _unitOfWork.SaveChangesAsync())
                return new GlobalResponse { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            return new GlobalResponse { IsSuccess = true, StatusCode = System.Net.HttpStatusCode.OK };
        }

        //api/Lookups/DeleteCategory/{id}
        public async Task<GlobalResponse> DeleteCategory(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
                return new GlobalResponse { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.NotFound };

            _unitOfWork.CategoryRepository.Delete(category);

            if (!await _unitOfWork.SaveChangesAsync())
                return new GlobalResponse { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
            return new GlobalResponse { IsSuccess = true, StatusCode = System.Net.HttpStatusCode.OK };



        }

        #endregion





    }
}
