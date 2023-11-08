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

public class ServiceStaffService : IServiceStaffService
{
    private readonly IRepository<StaffService> _repository;
    private readonly IMapper _mapper;

    public ServiceStaffService(IRepository<StaffService> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StaffServiceResultDto> CreateAsync(StaffServiceCreationDto dto)
    {
        var existingStaffService = await _repository.SelectAll()
            .Where(ss.)

        if (existingStaffService != null)
            throw new BeautySchedulerException(404, "Staff service relationship already exists");

        var mappedStaffService = _mapper.Map<StaffService>(dto);
        var result = await _repository.InsertAsync(mappedStaffService);

        return _mapper.Map<StaffServiceResultDto>(result);
    }

    public async Task<StaffServiceResultDto> ModifyAsync(StaffServiceUpdateDto dto)
    {
        var existingStaffService = await _repository.SelectByIdAsync(dto.Id);

        if (existingStaffService == null)
            throw new BeautySchedulerException(409, "Staff service relationship not found");

        existingStaffService.StaffId = dto.StaffId;
        existingStaffService.ServiceId = dto.ServiceId;

        await _repository.UpdateAsync(existingStaffService);

        return _mapper.Map<StaffServiceResultDto>(existingStaffService);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existingStaffService = await _repository.SelectByIdAsync(id);

        if (existingStaffService == null)
            throw new BeautySchedulerException(409, "Staff service relationship not found");

        await _repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<StaffServiceResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var staffServices = await _repository.SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<StaffServiceResultDto>>(staffServices);
    }

    public async Task<StaffServiceResultDto> RetrieveByIdAsync(long id)
    {
        var existingStaffService = await _repository.SelectByIdAsync(id);

        if (existingStaffService == null)
            throw new BeautySchedulerException(409, "Staff service relationship not found");

        return _mapper.Map<StaffServiceResultDto>(existingStaffService);
    }
}



