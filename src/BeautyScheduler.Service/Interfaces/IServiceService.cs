using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces
{
    public interface IServiceService
    {
        Task<ServiceResultDto> CreateAsync(ServiceCreationDto dto);
        Task<ServiceResultDto> ModifyAsync(ServiceUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<ServiceResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<ServiceResultDto> RetrieveByIdAsync(long id);
    }
}
