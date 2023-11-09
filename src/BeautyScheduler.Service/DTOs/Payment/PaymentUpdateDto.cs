using BeautyScheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.Payment
{
    public class PaymentUpdateDto
    {
        public long ServiceId { get; set; }
        public Pay PayType { get; set; }
        public decimal? Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
