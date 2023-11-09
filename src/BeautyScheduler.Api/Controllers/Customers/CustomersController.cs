using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers.Customers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] CustomerCreationDto dto)
            => Ok(await _customerService.AddAsync(dto));
        
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(await _customerService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
            => Ok(await _customerService.RetrieveByIdAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _customerService.RemoveAsync(id));

        [HttpPut]
        public async Task<IActionResult> PutAsync(long id, [FromForm] CustomerUpdateDto dto)
            => Ok(await _customerService.ModifyAsync(id,dto));
    }
}
