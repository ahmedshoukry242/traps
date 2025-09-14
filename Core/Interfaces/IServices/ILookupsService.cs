using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices
{
    public interface ILookupsService
    {
        Task<GlobalResponse> GetAllCountries();
        Task<GlobalResponse> GetAllStates(int countryId);
        Task<GlobalResponse> GetAllCategories();
        Task<GlobalResponse> CreateCategory(string name);
        Task<GlobalResponse> UpdateCategory(int id, string name);
        Task<GlobalResponse> DeleteCategory(int id);

    }
}
