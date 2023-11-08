using AutoMapper;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Domain.Entites;
using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.CustomerService;
using BeautyScheduler.Service.Exceptions;
using BeautyScheduler.Service.Extentions;
using BeautyScheduler.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeautyScheduler.Service.Services
{
    public class ServiceCustomerService : IServiceCustomerService
    {
        private readonly IRepository<ServiceCustomer> _repository;
        private readonly IMapper _mapper;

        public ServiceCustomerService(IRepository<ServiceCustomer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerServiceResultDto> CreateAsync(CustomerServiceCreationDto dto)
        {
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.ServiceId == dto.ServiceId && sc.CustomerId == dto.CustomerId)
                .FirstOrDefaultAsync();

            if (existingServiceCustomer != null)
                throw new BeautySchedulerException(404, "Service customer relationship already exists");

            var mappedServiceCustomer = _mapper.Map<ServiceCustomer>(dto);
            var result = await _repository.InsertAsync(mappedServiceCustomer);

            return _mapper.Map<CustomerServiceResultDto>(result);
        }

        public async Task<CustomerServiceResultDto> ModifyAsync(CustomerServiceUpdateDto dto)
        {
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.ServiceId == dto.ServiceId && sc.CustomerId==dto.CustomerId)
                .FirstOrDefaultAsync();

            if (existingServiceCustomer == null)
                throw new BeautySchedulerException(409, "Service customer relationship not found");

            existingServiceCustomer.UpdatedAt = DateTime.UtcNow;

            var mappedServiceCustomer = _mapper.Map(dto, existingServiceCustomer);

            await _repository.UpdateAsync(mappedServiceCustomer);

            return _mapper.Map<CustomerServiceResultDto>(mappedServiceCustomer);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.Id == id)
                .FirstOrDefaultAsync();

            if (existingServiceCustomer == null)
                throw new BeautySchedulerException(409, "Service customer relationship not found");

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<CustomerServiceResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var serviceCustomers = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CustomerServiceResultDto>>(serviceCustomers);
        }

        public async Task<CustomerServiceResultDto> RetrieveByIdAsync(long id)
        {
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.Id == id)
                .FirstOrDefaultAsync();

            if (existingServiceCustomer == null)
                throw new BeautySchedulerException(409, "Service customer relationship not found");

            return _mapper.Map<CustomerServiceResultDto>(existingServiceCustomer);
        }
    }

}
