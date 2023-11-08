using BeautyScheduler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.Staff
{
    public class StaffCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Gender GenderType { get; set; }
        public Specialty SpecialtyType { get; set; }
        public short WorkingHour { get; set; }
    }
}
