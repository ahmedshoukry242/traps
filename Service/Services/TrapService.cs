using AutoMapper;
using Core.Constants;
using Core.DTOs;
using Core.DTOs.Trap;
using Core.Entities;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Core.DTOs.Trap.TrapReadDTOs;

namespace Service.Services
{
    public class TrapService : ITrapService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _accessor;
        public TrapService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _accessor = accessor;
        }
        public async Task<GlobalResponse> AddTrap(TrapCreateDto dto)
        {
            Trap trap = _mapper.Map<Trap>(dto);
            trap = await _unitOfWork.TrapRepository.AddAsync(trap);

            if (!await _unitOfWork.SaveChangesAsync())
                return new GlobalResponse { IsSuccess = false, Message = "Faild To Add Trap!", StatusCode = HttpStatusCode.BadRequest };
            return new GlobalResponse { IsSuccess = true, Message = "Created!", StatusCode = HttpStatusCode.OK };
        }
        public async Task<GlobalResponse<ConfigurationsRead>> TrapConfigurations(string serialNumber)
        {
            var trap = await _unitOfWork.TrapRepository.GetFirstOrDefaultAsync(x => x.SerialNumber == serialNumber);

            if (trap == null) return new GlobalResponse<ConfigurationsRead> { IsSuccess = false, Message = $"No Traps found with that serial = {serialNumber}!", StatusCode = HttpStatusCode.BadRequest };

            var configurations = _mapper.Map<ConfigurationsRead>(trap);
            return new GlobalResponse<ConfigurationsRead> { Data = configurations, IsSuccess = true, Message = "Configurations retreived!", StatusCode = HttpStatusCode.OK };
        }

        #region GET
        public async Task<GlobalResponse> ListOfTrapsAsync(TrapFilters.TrapFilter filter)
        {

            ReadListResponse finalResult = new();
            var role = GetRoleName();
            if (role == RoleName.Superadmin)
            {
                var trapsQuery = _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking()
                    .Where(x => (filter.Name == null || x.Name!.Contains(filter.Name)) &&
                    (filter.SerialNumber == null || x.SerialNumber!.Contains(filter.SerialNumber)));

                var count = await trapsQuery.CountAsync();

                if (count <= 0)
                    return new GlobalResponse<ReadListResponse> { IsSuccess = true, Message = "No Data!", StatusCode = HttpStatusCode.OK, Data = finalResult };


                trapsQuery = ApplyPagination(trapsQuery, filter.PageNumber, filter.PageSize);




                var data = await trapsQuery.Select(x => new ReadListDto { Id = x.Id, Name = x.Name }).ToListAsync();

                finalResult = new ReadListResponse
                {
                    TotalRecords = count,
                    Data = data
                };
            }
            else
            {
                var useTrapsQuery = _unitOfWork.UserTrapsRepository.GetAllQueryableAsNoTracking()
                    .Where(x =>
                    x.UserId == GetUserId() &&
                    (filter.Name == null || x.Trap.Name!.Contains(filter.Name)) &&
                    (filter.SerialNumber == null || x.Trap.SerialNumber!.Contains(filter.SerialNumber)));

                var count = await useTrapsQuery.CountAsync();

                if (count <= 0)
                    return new GlobalResponse<ReadListResponse> { IsSuccess = true, Message = "No Data!", StatusCode = HttpStatusCode.OK, Data = finalResult };

                useTrapsQuery = ApplyPagination(useTrapsQuery, filter.PageNumber, filter.PageSize);

                var data = await useTrapsQuery.Select(x => new ReadListDto { Id = x.TrapId, Name = x.Trap.Name }).OrderByDescending(x => x.Id).ToListAsync();

                finalResult = new ReadListResponse
                {
                    TotalRecords = count,
                    Data = data
                };
            }
            return new GlobalResponse<ReadListResponse> { Data = finalResult, IsSuccess = true, Message = "Data retrieved!", StatusCode = HttpStatusCode.OK };
        }

        public async Task<GlobalResponse> GetAllTrapsAsync(TrapFilters.trapAllFilter filter)
        {
            List<GetTrapresponse> traps;

            if (filter.UserId is not null || GetRoleName() != RoleName.Superadmin)
            {
                Guid uId = GetUserId();

                if (filter.UserId is not null)
                    uId = Guid.Parse(filter.UserId);

                traps = await _unitOfWork.UserTrapsRepository.GetAllQueryableAsNoTracking()
                        .Where(
                        x => x.UserId == uId
                                                                                &&
                                                                                (filter.TrapId == null || x.TrapId == filter.TrapId)
                                                                                &&
                                                                                (filter.SerialNumber == null || x.Trap.SerialNumber == filter.SerialNumber)
                                                                                &&
                                                                                (filter.categoryId == 0 || x.Trap.CategoryId == filter.categoryId)
                                                                                )
                        .Select(UserTrapsProjection()).ToListAsync();
            }
            else // superadmin or not filters with userId
            {
                traps = await _unitOfWork.TrapRepository.GetAllQueryableAsNoTracking()
                    .Where(x =>
                                                 (filter.TrapId == null || x.Id == filter.TrapId) &&
                                                 (filter.SerialNumber == null || x.SerialNumber!.Contains(filter.SerialNumber)) &&
                                                 (filter.categoryId == 0 || x.CategoryId == filter.categoryId))
                    .Select(TrapsProjection()).ToListAsync();
            }

            return new GlobalResponse<List<GetTrapresponse>>
            {
                Data = traps,
                IsSuccess = true,
                Message = traps.Any() ? "Data Retrieved!" : "No Data Found!",
                StatusCode = HttpStatusCode.OK
            };
        }
        #endregion


        #region Modifications
        public async Task<GlobalResponse> UpdateTrap(TrapUpdateDto dto)
        {
            try
            {
                // Check if trap exists
                var existingTrap = await _unitOfWork.TrapRepository.GetByIdAsync(dto.Id);
                if (existingTrap == null)
                {
                    return new GlobalResponse
                    {
                        IsSuccess = false,
                        Message = "Trap not found!",
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                // Begin transaction for update
                await _unitOfWork.BeginTransactionAsync();

                // Map updated values to existing trap
                _mapper.Map(dto, existingTrap);
                _unitOfWork.TrapRepository.Update(existingTrap);

                // Save changes
                if (await _unitOfWork.SaveChangesAsync())
                {
                    await _unitOfWork.CommitTransactionAsync();
                    return new GlobalResponse
                    {
                        IsSuccess = true,
                        Message = "Trap updated successfully!",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new GlobalResponse
                    {
                        IsSuccess = false,
                        Message = "Failed to update trap!",
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GlobalResponse
                {
                    IsSuccess = false,
                    Message = $"Error occurred while updating trap: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            finally
            {
                await _unitOfWork.DisposeTransactionAsync();
            }
        }

        public async Task<GlobalResponse> DeleteTrapAsync(int id)
        {
            try
            {
                // Check if trap exists
                var trap = await _unitOfWork.TrapRepository.GetByIdAsync(id);
                if (trap == null)
                {
                    return new GlobalResponse
                    {
                        IsSuccess = false,
                        Message = "Trap not found!",
                        StatusCode = HttpStatusCode.NotFound
                    };
                }

                // Begin transaction for cascade delete
                await _unitOfWork.BeginTransactionAsync();

                // Delete TrapEmergency records
                var trapEmergencies = _unitOfWork.TrapEmergencyRepository.GetAllQueryable()
                    .Where(x => x.TrapId == id).ToList();
                if (trapEmergencies.Any())
                {
                    _unitOfWork.TrapEmergencyRepository.DeleteRangeAsync(trapEmergencies);
                }

                // Delete TrapFanSchedule records
                var trapFanSchedules = _unitOfWork.TrapFanScheduleRepository.GetAllQueryable()
                    .Where(x => x.TrapId == id).ToList();
                if (trapFanSchedules.Any())
                {
                    _unitOfWork.TrapFanScheduleRepository.DeleteRangeAsync(trapFanSchedules);
                }

                // Delete TrapRead records (and their related ReadDetails will be handled by cascade)
                var trapReads = _unitOfWork.TrapReadRepository.GetAllQueryable()
                    .Where(x => x.TrapId == id).ToList();
                if (trapReads.Any())
                {
                    _unitOfWork.TrapReadRepository.DeleteRangeAsync(trapReads);
                }

                // Delete TrapValveQutSchedule records
                var trapValveQutSchedules = _unitOfWork.TrapValveQutScheduleRepository.GetAllQueryable()
                    .Where(x => x.TrapId == id).ToList();
                if (trapValveQutSchedules.Any())
                {
                    _unitOfWork.TrapValveQutScheduleRepository.DeleteRangeAsync(trapValveQutSchedules);
                }

                // Delete TrapCounterSchedule records
                var trapCounterSchedules = _unitOfWork.TrapCounterScheduleRepository.GetAllQueryable()
                    .Where(x => x.TrapId == id).ToList();
                if (trapCounterSchedules.Any())
                {
                    _unitOfWork.TrapCounterScheduleRepository.DeleteRangeAsync(trapCounterSchedules);
                }

                // Delete UserTraps records
                var userTraps = _unitOfWork.UserTrapsRepository.GetAllQueryable()
                    .Where(x => x.TrapId == id).ToList();
                if (userTraps.Any())
                {
                    _unitOfWork.UserTrapsRepository.DeleteRangeAsync(userTraps);
                }

                // Finally delete the Trap itself
                _unitOfWork.TrapRepository.Delete(trap);

                // Save all changes
                if (await _unitOfWork.SaveChangesAsync())
                {
                    await _unitOfWork.CommitTransactionAsync();
                    return new GlobalResponse
                    {
                        IsSuccess = true,
                        Message = "Trap and all related records deleted successfully!",
                        StatusCode = HttpStatusCode.OK
                    };
                }
                else
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    return new GlobalResponse
                    {
                        IsSuccess = false,
                        Message = "Failed to delete trap!",
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return new GlobalResponse
                {
                    IsSuccess = false,
                    Message = $"Error occurred while deleting trap: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
            finally
            {
                await _unitOfWork.DisposeTransactionAsync();
            }
        }

        #endregion

        #region Helpers
        private string GetRoleName() =>
        _accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.FindFirstValue(ClaimTypes.Role);

        private Guid GetUserId() =>
        Guid.Parse(_accessor!.HttpContext == null ? string.Empty : _accessor!.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier));

        private IQueryable<T> ApplyPagination<T>(IQueryable<T> query, int? PageNumber, int? PageSize) where T : class
        {
            if (PageSize != null && PageNumber != null)
                query = query.Skip((PageNumber.Value - 1) * PageSize.Value).Take(PageSize.Value);
            return query;
        }

        #endregion

        #region Projection
        private static Expression<Func<UserTraps, GetTrapresponse>> UserTrapsProjection()
        {
            return x => new GetTrapresponse
            {
                Id = x.TrapId,
                Name = x.Trap.Name,
                SerialNumber = x.Trap.SerialNumber,
                Status = x.Trap.TrapStatus,
                Iema = x.Trap.Iema,
                ValveQut = x.Trap.ValveQut,
                Fan = x.Trap.Fan,
                IsCounterOn = x.Trap.IsCounterOn,
                IsCounterReadingFromSimCard = x.Trap.IsCounterReadingFromSimCard,
                ReadingDate = x.Trap.ReadingDate,
                Lat = x.Trap.Lat,
                Long = x.Trap.Long,
                IsScheduleOn = x.Trap.IsScheduleOn,
                BigBattery = x.Trap.BigBattery,
                SmallBattery = x.Trap.SmallBattery,
                FileDate = x.Trap.FileDate,
                IsThereEmergency = x.Trap.IsThereEmergency,
                categoryId = x.Trap.CategoryId,
                CountryId = x.Trap.CountryId,
                StateId = x.Trap.StateId,
                TrapEmergencies = x.Trap.TrapEmergencies.Select(e => new Core.DTOs.Trap.TrapEmergency.EmergencyReadDto.GetTrapEmergency
                {
                    Id = e.Id,
                    TrapId = e.TrapId,
                    Date = e.Date,
                    Lat = e.Lat,
                    Long = e.Long
                }),
                TrapCounterSchedules = x.Trap.TrapCounterSchedules.Select(s => new Core.DTOs.Trap.TrapSchedule.TrapScheduleDto
                {
                    ScdTime = s.ScdTime,
                    Status = s.Status
                }),
                TrapFanSchedules = x.Trap.TrapFanSchedules.Select(s => new Core.DTOs.Trap.TrapSchedule.TrapScheduleDto
                {
                    ScdTime = s.ScdTime,
                    Status = s.Status
                }),
                TrapValveQutSchedules = x.Trap.TrapValveQutSchedules.Select(s => new Core.DTOs.Trap.TrapSchedule.TrapScheduleDto
                {
                    ScdTime = s.ScdTime,
                    Status = s.Status
                }),
            };
        }
        private static Expression<Func<Trap, GetTrapresponse>> TrapsProjection()
        {
            return x => new GetTrapresponse
            {
                Id = x.Id,
                Name = x.Name,
                SerialNumber = x.SerialNumber,
                Status = x.TrapStatus,
                Iema = x.Iema,
                ValveQut = x.ValveQut,
                Fan = x.Fan,
                IsCounterOn = x.IsCounterOn,
                IsCounterReadingFromSimCard = x.IsCounterReadingFromSimCard,
                ReadingDate = x.ReadingDate,
                Lat = x.Lat,
                Long = x.Long,
                IsScheduleOn = x.IsScheduleOn,
                BigBattery = x.BigBattery,
                SmallBattery = x.SmallBattery,
                FileDate = x.FileDate,
                IsThereEmergency = x.IsThereEmergency,
                categoryId = x.CategoryId,
                CountryId = x.CountryId,
                StateId = x.StateId,
                TrapEmergencies = x.TrapEmergencies.Select(e => new Core.DTOs.Trap.TrapEmergency.EmergencyReadDto.GetTrapEmergency
                {
                    Id = e.Id,
                    TrapId = e.TrapId,
                    Date = e.Date,
                    Lat = e.Lat,
                    Long = e.Long
                }),
                TrapCounterSchedules = x.TrapCounterSchedules.Select(s => new Core.DTOs.Trap.TrapSchedule.TrapScheduleDto
                {
                    ScdTime = s.ScdTime,
                    Status = s.Status
                }),
                TrapFanSchedules = x.TrapFanSchedules.Select(s => new Core.DTOs.Trap.TrapSchedule.TrapScheduleDto
                {
                    ScdTime = s.ScdTime,
                    Status = s.Status
                }),
                TrapValveQutSchedules = x.TrapValveQutSchedules.Select(s => new Core.DTOs.Trap.TrapSchedule.TrapScheduleDto
                {
                    ScdTime = s.ScdTime,
                    Status = s.Status
                }),
            };
        }
        #endregion
    }
}
