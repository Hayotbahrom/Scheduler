using BeautyScheduler.Service.DTOs.Service;
using BeautyScheduler.Service.DTOs.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.StaffService
{
    public class StaffServiceResultDto
    {
        public long StaffId { get; set; }
        public StaffResultDto Staff {  get; set; }
        public long ServiceId { get; set; }
        public ServiceResultDto Service {  get; set; }
    }
}
