using BeautyScheduler.Service.Configurations;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResultDto> CreateAsync(PaymentCreationDto dto);
        Task<PaymentResultDto> ModifyAsync(PaymentUpdateDto dto);
        Task<bool> RemoveAsync(long id);
        Task<IEnumerable<PaymentResultDto>> RetrieveAllAsync(PaginationParams @params);
        Task<PaymentResultDto> RetrieveByIdAsync(long id);

    }
}
