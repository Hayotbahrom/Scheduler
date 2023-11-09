using AutoMapper;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Domain.Entites;
using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Staff;
using BeautyScheduler.Service.Exceptions;
using BeautyScheduler.Service.Extentions;
using BeautyScheduler.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeautyScheduler.Service.Services
{
    public class StaffService : IStaffService
    {
        private readonly IRepository<Staff> _repository;
        private readonly IMapper _mapper;

        public StaffService(IRepository<Staff> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StaffResultDto> CreateAsync(StaffCreationDto dto)
        {
            var staff = await _repository.SelectAll()
                .Where(s => s.Email.ToLower() == dto.Email.ToLower())
                .FirstOrDefaultAsync();

            if (staff is not null)
                throw new BeautySchedulerException(404, "staff member already exists");

            var mappedStaff = _mapper.Map<Staff>(dto);
            var result = await _repository.InsertAsync(mappedStaff);

            return _mapper.Map<StaffResultDto>(result);
        }

        public async Task<StaffResultDto> ModifyAsync(long id, StaffUpdateDto dto)
        {
            var staff = await _repository.SelectAll()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (staff is null)
                throw new BeautySchedulerException(409, "staff member not found");

            staff.UpdatedAt = DateTime.UtcNow;

            var mappedStaff = _mapper.Map(dto, staff);

            await _repository.UpdateAsync(mappedStaff);

            return _mapper.Map<StaffResultDto>(mappedStaff);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var staff = await _repository.SelectAll()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (staff is null)
                throw new BeautySchedulerException(409, "staff member not found");

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<StaffResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var staffList = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<StaffResultDto>>(staffList);
        }

        public async Task<StaffResultDto> RetrieveByIdAsync(long id)
        {
            var staff = await _repository.SelectAll()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (staff is null)
                throw new BeautySchedulerException(409, "staff member not found");

            return _mapper.Map<StaffResultDto>(await _repository.SelectByIdAsync(id));
        }
    }

}
