using AutoMapper;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Domain.Entites;
using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
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
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerResultDto> AddAsync(CustomerCreationDto dto)
        {
            var customer = await _repository.SelectAll()
                .Where(c => c.Email.ToLower() == dto.Email.ToLower())
                .FirstOrDefaultAsync();

            if (customer is not null)
                throw new BeautySchedulerException(404, "customer already exist");
            
            var mappedCustomer = _mapper.Map<Customer>(dto);
            var result =  await _repository.InsertAsync(mappedCustomer);

            return _mapper.Map<CustomerResultDto>(result);
        }

        public async Task<CustomerResultDto> ModifyAsync(CustomerUpdateDto dto)
        {
            var customer = await _repository.SelectAll()
                .Where(c => c.Email.ToLower() == dto.Email.ToLower())
                .FirstOrDefaultAsync();

            if (customer is null)
                throw new BeautySchedulerException(409,"customer is not found");

            customer.UpdatedAt = DateTime.UtcNow;
            
            var mappedCustomer = _mapper.Map(dto, customer);

            await _repository.UpdateAsync(mappedCustomer);

            return _mapper.Map<CustomerResultDto>(mappedCustomer);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var customer = await _repository.SelectAll()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (customer is null)
                throw new BeautySchedulerException(409, "customer is not found");

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<CustomerResultDto>> RetrieveAllAsync(PaginationParams @params)
        {
            var customers = await _repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(@params)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CustomerResultDto>>(customers); 
        }

        public async Task<CustomerResultDto> RetrieveByIdAsync(long id)
        {
            var customer = await _repository.SelectAll()
                .Where(c => c.Id==id)
                .FirstOrDefaultAsync();

            if (customer is null)
                throw new BeautySchedulerException(409, "customer is not found");
            
            return _mapper.Map<CustomerResultDto>(await _repository.SelectByIdAsync(id));
        }
    }
}
