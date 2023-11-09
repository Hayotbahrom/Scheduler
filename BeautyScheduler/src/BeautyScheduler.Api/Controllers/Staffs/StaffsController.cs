using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.Staff;
using BeautyScheduler.Service.DTOs.StaffService;
using BeautyScheduler.Service.Interfaces;
using BeautyScheduler.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers.Staffs
{
    public class StaffsController:BaseController
    {
        private readonly IStaffService staffService;

        public StaffsController(IStaffService staffService)
        {
            this.staffService = staffService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(StaffCreationDto dto)
        => Ok(await staffService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(await staffService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
            => Ok(await staffService.RetrieveByIdAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await staffService.RemoveAsync(id));

        [HttpPut]
        public async Task<IActionResult> PutAsync(long id, StaffUpdateDto dto)
            => Ok(await staffService.ModifyAsync(id, dto));
    }
}
