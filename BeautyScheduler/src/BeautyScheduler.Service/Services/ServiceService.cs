using AutoMapper;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Service;
using BeautyScheduler.Service.Exceptions;
using BeautyScheduler.Service.Extentions;
using BeautyScheduler.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<BeautyScheduler.Domain.Entites.Service> _repository;
        private readonly IMapper _mapper;

        public ServiceService(IRepository<BeautyScheduler.Domain.Entites.Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResultDto> CreateAsync(ServiceCreationDto dto)
        {
            var existingService = await _repository.SelectAll()
                .Where(s => s.ServiceName.ToLower() == dto.ServiceName.ToLower())
                .FirstOrDefaultAsync();

            if (existingService != null)
                throw new BeautySchedulerException(404, "Service already exists");

            var mappedService = _mapper.Map<BeautyScheduler.Domain.Entites.Service>(dto);
            var result = await _repository.InsertAsync(mappedService);

            return _mapper.Map<ServiceResultDto>(result);
        }

        public async Task<ServiceResultDto> ModifyAsync(ServiceUpdateDto dto)
        {
            var existingService = await _repository.SelectByIdAsync(dto.Id);

            if (existingService == null)
                throw new BeautySchedulerException(409, "Service not found");

            existingService.ServiceName = dto.ServiceName;
            existingService.Description = dto.Description;
            existingService.Duration = dto.Duration;
            existingService.Price = dto.Price;
            

            await _repository.UpdateAsync(existingService);

            return _mapper.Map<ServiceResultDto>(existingService);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var existingService = await _repository.SelectByIdAsync(id);

            if (existingService == null)
                throw new BeautySchedulerException(409, "Service not found");

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ServiceResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var services = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ServiceResultDto>>(services);
        }

        public async Task<ServiceResultDto> RetrieveByIdAsync(long id)
        {
            var existingService = await _repository.SelectByIdAsync(id);

            if (existingService == null)
                throw new BeautySchedulerException(409, "Service not found");

            return _mapper.Map<ServiceResultDto>(existingService);
        }
    }

}
