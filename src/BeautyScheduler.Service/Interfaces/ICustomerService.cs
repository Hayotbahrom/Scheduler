using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResultDto> AddAsync(CustomerCreationDto dto);
        Task<CustomerResultDto> ModifyAsync(long id, CustomerUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<CustomerResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<CustomerResultDto> RetrieveByIdAsync(long id);
    }
}
