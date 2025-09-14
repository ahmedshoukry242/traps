using Core.DTOs;
using Core.DTOs.Trap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices
{
    public interface ITrapService
    {
        Task<GlobalResponse> AddTrap(TrapCreateDto dto);
        Task<GlobalResponse<ConfigurationsRead>> TrapConfigurations(string serialNumber);


        #region GET
        Task<GlobalResponse> ListOfTrapsAsync(TrapFilters.TrapFilter filter);
        Task<GlobalResponse> GetAllTrapsAsync(TrapFilters.trapAllFilter filter);
        #endregion
    }
}
