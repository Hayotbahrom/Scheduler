using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.CustomerService;
using BeautyScheduler.Service.Interfaces;
using BeautyScheduler.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers.ServiceCustomersController
{
    public class ServiceCustomersController : BaseController
    {
        private readonly IServiceCustomerService serviceCustomerService;

        public ServiceCustomersController(IServiceCustomerService serviceCustomerService)
        {
            this.serviceCustomerService = serviceCustomerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(CustomerServiceCreationDto dto)
        => Ok(await serviceCustomerService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(await serviceCustomerService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
            => Ok(await serviceCustomerService.RetrieveByIdAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await serviceCustomerService.RemoveAsync(id));

        [HttpPut]
        public async Task<IActionResult> PutAsync(long id, CustomerServiceUpdateDto dto)
            => Ok(await serviceCustomerService.ModifyAsync(id, dto));
    }

}
