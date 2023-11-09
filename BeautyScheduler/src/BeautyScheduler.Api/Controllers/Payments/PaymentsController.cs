using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.Payment;
using BeautyScheduler.Service.Interfaces;
using BeautyScheduler.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeautyScheduler.Api.Controllers.Payments
{
    public class PaymentsController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(PaymentCreationDto dto)
        => Ok(await _paymentService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params)
            => Ok(await _paymentService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
            => Ok(await _paymentService.RetrieveByIdAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        => Ok(await _paymentService.RemoveAsync(id));

        [HttpPut]
        public async Task<IActionResult> PutAsync(long id, PaymentUpdateDto dto)
            => Ok(await _paymentService.ModifyAsync(id, dto));
    }
}
