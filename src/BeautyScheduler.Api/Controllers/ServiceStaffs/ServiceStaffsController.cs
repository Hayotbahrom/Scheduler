using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.StaffService;
using BeautyScheduler.Service.Interfaces;
using BeautyScheduler.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers.ServiceStaffs
{
    public class ServiceStaffsController : BaseController
    {
        private readonly IServiceStaffService _serviceStaffService;

        public ServiceStaffsController(IServiceStaffService serviceStaffService)
        {
            _serviceStaffService = serviceStaffService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(StaffServiceCreationDto dto)
            => Ok(await _serviceStaffService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(await _serviceStaffService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
            => Ok(await _serviceStaffService.RetrieveByIdAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _serviceStaffService.RemoveAsync(id));

        [HttpPut]
        public async Task<IActionResult> PutAsync(long id, StaffServiceUpdateDto dto)
            => Ok(await _serviceStaffService.ModifyAsync(id, dto));
    }
}
