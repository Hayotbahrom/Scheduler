using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.CustomerService
{
    public class CustomerServiceUpdateDto
    {
        public long CustomerId { get; set; }
        public long ServiceId { get; set; }
    }
}
