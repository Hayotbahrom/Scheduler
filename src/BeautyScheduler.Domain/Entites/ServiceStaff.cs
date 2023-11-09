using BeautyScheduler.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Domain.Entites
{
    public class ServiceStaff : Auditable
    {
        public long StaffId { get; set; }
        public Staff Staff { get; set; }
        public long ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
