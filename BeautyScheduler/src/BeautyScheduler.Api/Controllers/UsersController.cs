using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public UsersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await customerService.RetrieveAllAsync(@params));
    }
}
