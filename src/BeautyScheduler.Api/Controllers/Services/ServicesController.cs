using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.CustomerService;
using BeautyScheduler.Service.DTOs.Service;
using BeautyScheduler.Service.Interfaces;
using BeautyScheduler.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers.Services
{
    public class ServicesController:BaseController
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(ServiceCreationDto dto)
        => Ok(await _serviceService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(await _serviceService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
            => Ok(await _serviceService.RetrieveByIdAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await _serviceService.RemoveAsync(id));

        [HttpPut]
        public async Task<IActionResult> PutAsync( ServiceUpdateDto dto)
            => Ok(await _serviceService.ModifyAsync( dto));
    }
}
