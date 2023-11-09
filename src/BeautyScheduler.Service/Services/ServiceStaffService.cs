using AutoMapper;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.StaffService;
using BeautyScheduler.Service.Exceptions;
using BeautyScheduler.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Services;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper; // Make sure to include the necessary using directives
using BeautyScheduler.Service.Extentions;
using BeautyScheduler.Data.Repositories;
using BeautyScheduler.Domain.Entites;

public class ServiceStaffService : IServiceStaffService
{
    private readonly IMapper _mapper;
    private readonly IServiceRepository _serviceRepository;
    private readonly IStaffRepository _staffRepository;
    private readonly IServiceStaffRepository _staffServiceRepository;

    public ServiceStaffService(
        IMapper mapper,
        IServiceRepository serviceRepository,
        IStaffRepository staffRepository,
        IServiceStaffRepository staffServiceRepository)
    {
        _mapper = mapper;
        _serviceRepository = serviceRepository;
        _staffRepository = staffRepository;
        _staffServiceRepository = staffServiceRepository;
    }

    public async Task<StaffServiceResultDto> CreateAsync(StaffServiceCreationDto dto)
    {
        //var staff = await _staffRepository.SelectAll()
        //    .Where(s => s.Id == dto.StaffId)
        //    .FirstOrDefaultAsync();
        //if (staff is not null)
        //    throw new BeautySchedulerException(409, "Customer is already  exist");

        //var existingService = await _serviceRepository.SelectAll()
        //        .Where(s => s.Id == dto.ServiceId)
        //        .FirstOrDefaultAsync();
        //if (existingService != null)
        //    throw new BeautySchedulerException(404, "Service already exists");

        var mappedStaffService = _mapper.Map<ServiceStaff>(dto);
        
        var result = await _staffServiceRepository.InsertAsync(mappedStaffService);

        return _mapper.Map<StaffServiceResultDto>(result);
    }

    public async Task<StaffServiceResultDto> ModifyAsync(long id, StaffServiceUpdateDto dto)
    {
        var serviceStaff = await _staffServiceRepository.SelectAll()
            .Where(ss => ss.Id == id)
            .FirstOrDefaultAsync();

        if (serviceStaff is null)
            throw new BeautySchedulerException(404, "StaffService is not found");

        //var staff = await _staffRepository.SelectAll()
        //    .Where(s => s.Id == dto.StaffId)
        //    .FirstOrDefaultAsync();
        //if (staff is  null)
        //    throw new BeautySchedulerException(409, "Customer is not found");

        //var existingService = await _serviceRepository.SelectAll()
        //        .Where(s => s.Id == dto.ServiceId)
        //        .FirstOrDefaultAsync();
        //if (existingService is null)
        //    throw new BeautySchedulerException(404, "Service is not found");

        var mappedServiceStaff = _mapper.Map(dto, serviceStaff);
        var result = await _staffServiceRepository.UpdateAsync(mappedServiceStaff);

        return _mapper.Map<StaffServiceResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var serviceStaff = await _staffServiceRepository.SelectAll()
            .Where(ss => ss.Id == id)
            .FirstOrDefaultAsync();
        if (serviceStaff is null)
            throw new BeautySchedulerException(404, "StaffService is not found");

        return await _staffServiceRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<StaffServiceResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var serviceStaffs = await _staffServiceRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();
        return _mapper.Map<IEnumerable<StaffServiceResultDto>>(serviceStaffs);
    }

    public async Task<StaffServiceResultDto> RetrieveByIdAsync(long id)
    {
        var serviceStaff = await _staffServiceRepository.SelectByIdAsync(id);
        if (serviceStaff is null)
            throw new BeautySchedulerException(404, "Staff Service is not found");

        return _mapper.Map<StaffServiceResultDto>(serviceStaff);
    }
}



