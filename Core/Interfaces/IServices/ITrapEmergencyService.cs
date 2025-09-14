using Core.DTOs;
using Core.DTOs.Trap.TrapEmergency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.IServices
{
    public interface ITrapEmergencyService
    {
        Task<GlobalResponse> GetAllTrapEmergenciesAsync(string serialNumber, int month, int year, bool EmergenciesGroupByYear);
        Task<GlobalResponse> CreateTrapEmergencyAsync(EmergencyWrite emergencyWrite);
    }
}
