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
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceRepository _serviceRepository;

        public ServiceCustomerService(
            IRepository<ServiceCustomer> repository,
            IMapper mapper,
            ICustomerRepository customerRepository,
            IServiceRepository serviceRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<CustomerServiceResultDto> CreateAsync(CustomerServiceCreationDto dto)
        {
            //// Check if the customer exists
            //var customer = await _customerRepository.SelectAll()
            //    .Where(c => c.Id == dto.CustomerId)
            //    .FirstOrDefaultAsync();
            //if (customer is not null)
            //    throw new BeautySchedulerException(409, "Customer is already exist");

            //// Check if the service exists
            //var existingService = await _serviceRepository.SelectAll()
            //    .Where(s => s.Id == dto.ServiceId)
            //    .FirstOrDefaultAsync();
            //if (existingService is not null)
            //    throw new BeautySchedulerException(404, "Service is already found");

            // Map DTO to entity
            var mappedServiceCustomer = _mapper.Map<ServiceCustomer>(dto);

            // Insert into repository
            var result = await _repository.InsertAsync(mappedServiceCustomer);

            return _mapper.Map<CustomerServiceResultDto>(result);
        }

        public async Task<CustomerServiceResultDto> ModifyAsync(long id, CustomerServiceUpdateDto dto)
        {
            // Check if the service customer relationship exists
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.ServiceId == dto.ServiceId && sc.CustomerId == dto.CustomerId)
                .FirstOrDefaultAsync();
            if (existingServiceCustomer == null)
                throw new BeautySchedulerException(409, "Service customer relationship not found");

            // Check if the customer exists
            var customer = await _customerRepository.SelectAll()
                .Where(c => c.Id == dto.CustomerId)
                .FirstOrDefaultAsync();
            if (customer is null)
                throw new BeautySchedulerException(409, "Customer not found");

            // Check if the service exists
            var existingService = await _serviceRepository.SelectAll()
                .Where(s => s.Id == dto.ServiceId)
                .FirstOrDefaultAsync();
            if (existingService is null)
                throw new BeautySchedulerException(404, "Service not found");

            // Update entity with DTO values
            var mappedServiceCustomer = _mapper.Map(dto, existingServiceCustomer);

            // Update in repository
            var result = await _repository.UpdateAsync(mappedServiceCustomer);

            return _mapper.Map<CustomerServiceResultDto>(result);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            // Check if the service customer relationship exists
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.Id == id)
                .FirstOrDefaultAsync();
            if (existingServiceCustomer == null)
                throw new BeautySchedulerException(404, "Service customer relationship not found");

            // Delete from repository
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerServiceResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            // Retrieve all service customer relationships from the repository
            var serviceCustomers = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CustomerServiceResultDto>>(serviceCustomers);
        }

        public async Task<CustomerServiceResultDto> RetrieveByIdAsync(long id)
        {
            // Retrieve service customer relationship by ID from the repository
            var existingServiceCustomer = await _repository.SelectAll()
                .Where(sc => sc.Id == id)
                .FirstOrDefaultAsync();
            if (existingServiceCustomer == null)
                throw new BeautySchedulerException(404, "Service customer relationship not found");

            return _mapper.Map<CustomerServiceResultDto>(existingServiceCustomer);
        }
    }


}
