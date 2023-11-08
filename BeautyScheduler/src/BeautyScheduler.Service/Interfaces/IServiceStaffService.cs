using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.StaffService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces
{
    public interface IServiceStaffService
    {
        Task<StaffServiceResultDto> CreateAsync(StaffServiceCreationDto dto);
        Task<StaffServiceResultDto> ModifyAsync(StaffServiceUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<StaffServiceResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<StaffServiceResultDto> RetrieveByIdAsync(long id);
    }
}
