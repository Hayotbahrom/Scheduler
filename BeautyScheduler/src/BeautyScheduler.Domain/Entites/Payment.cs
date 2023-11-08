using BeautyScheduler.Domain.Commons;
using BeautyScheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Domain.Entites
{
    public class Payment : Auditable
    {
        public long ServiceId { get; set; }
        public Service Service { get; set; }
        public Pay PayType {  get; set; }
        public decimal? Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
