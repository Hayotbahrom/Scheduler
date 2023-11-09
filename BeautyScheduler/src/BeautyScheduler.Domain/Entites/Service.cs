using BeautyScheduler.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Domain.Entites
{
    public class Service : Auditable
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public long Duration { get; set; }
        public decimal Price { get; set; }
        public ICollection<ServiceCustomer> CustomersServices { get; set; }
        public ICollection<ServiceStaff> StaffServices { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
