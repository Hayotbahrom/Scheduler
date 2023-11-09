using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces
{
    public interface IStaffService
    {
        Task<StaffResultDto> CreateAsync(StaffCreationDto dto);
        Task<StaffResultDto> ModifyAsync(long id, StaffUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<StaffResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<StaffResultDto> RetrieveByIdAsync(long id);
    }
}
