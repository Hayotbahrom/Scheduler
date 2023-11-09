using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces
{
    public interface IServiceCustomerService
    {
        Task<CustomerServiceResultDto> CreateAsync(CustomerServiceCreationDto dto);
        Task<CustomerServiceResultDto> ModifyAsync(long id, CustomerServiceUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<CustomerServiceResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<CustomerServiceResultDto> RetrieveByIdAsync(long id);
    }
}
