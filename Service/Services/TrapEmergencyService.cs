using Core.DTOs;
using Core.DTOs.Trap.TrapEmergency;
using Core.Entities;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.Services
{
    public class TrapEmergencyService : ITrapEmergencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrapEmergencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GlobalResponse> GetAllTrapEmergenciesAsync(string serialNumber, int month, int year, bool EmergenciesGroupByYear)
        {
            try
            {
                // prepare filter
                Expression<Func<TrapEmergency, bool>> filter = x => x.Trap.SerialNumber == serialNumber &&
                    (year == 0 || x.Date >= new DateTime(year, 1, 1) && x.Date < new DateTime(year + 1, 1, 1));

                if (year != 0 && month != 0)
                {
                    var startMonth = new DateTime(year, month, 1);
                    var endMonth = startMonth.AddMonths(1);
                    filter = x => x.Trap.SerialNumber == serialNumber &&
                        x.Date >= startMonth && x.Date < endMonth;
                }

                var emergencies = _unitOfWork.TrapEmergencyRepository.GetAllQueryableAsNoTracking().Include(x => x.Trap)
               .Where(filter)
               .Select(x => new EmergencyReadDto.EmergencyProjectionDto
               {
                   Id = x.Id,
                   Lat = x.Lat,
                   Long = x.Lat,
                   SerialNumber = x.Trap.SerialNumber,
                   DateTime = x.Date
               }).OrderByDescending(x => x.Id);


                var emergenciesList = await emergencies.Select(x => new EmergencyReadDto.EmergencyDto
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    Lat = x.Lat,
                    Long = x.Long,
                    DateTime = x.DateTime
                }).ToListAsync();

                dynamic finalResult = emergenciesList;

                if (EmergenciesGroupByYear)
                {
                    finalResult = emergenciesList.GroupBy(x => x.Year)
                    .Select(x => new EmergencyReadDto.GrouppedEmergency
                    {
                        Year = x.Key,
                        Emergencies = x.Select(x => x).ToList()
                    }).ToList();
                }

                return new GlobalResponse<object> { Data = finalResult, IsSuccess = true, Message = "Data retrieved!", StatusCode = System.Net.HttpStatusCode.OK };
            }
            catch
            {
                return new GlobalResponse { IsSuccess = false, Message = "Bad Request", StatusCode = System.Net.HttpStatusCode.BadRequest };
            }
        }

        public async Task<GlobalResponse> CreateTrapEmergencyAsync(EmergencyWrite emergencyWrite)
        {
            var trap = await _unitOfWork.TrapRepository.GetFirstOrDefaultAsync(x => x.SerialNumber == emergencyWrite.SerialNumber);

            if (trap is null)
                return new GlobalResponse { IsSuccess = false, Message = "Trap Not Found!", StatusCode = System.Net.HttpStatusCode.BadRequest };

            await _unitOfWork.BeginTransactionAsync();

            trap.IsThereEmergency = true;
            _unitOfWork.TrapRepository.Update(trap);
            if (!await _unitOfWork.SaveChangesAsync())
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GlobalResponse { IsSuccess = true, Message = "Failed to update trap emergency status!", StatusCode = System.Net.HttpStatusCode.BadRequest };
            }

            await _unitOfWork.TrapEmergencyRepository.AddAsync(new Core.Entities.TrapEmergency
            {
                Date = emergencyWrite.Date,
                Lat = emergencyWrite.Lat,
                Long = emergencyWrite.Long,
                TrapId = trap.Id,
                InsertDate = DateTime.Now
            });

            if (!await _unitOfWork.SaveChangesAsync())
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GlobalResponse { IsSuccess = true, Message = "Failed to add emergency!", StatusCode = System.Net.HttpStatusCode.BadRequest };
            }

            await _unitOfWork.CommitTransactionAsync();
            return new GlobalResponse { IsSuccess = true, Message = "Emergency Added!", StatusCode = System.Net.HttpStatusCode.OK, };
        }


    }
}
