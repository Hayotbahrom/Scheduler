using BeautyScheduler.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.Customer
{
    public class CustomerUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Gender GenderType { get; set; }
        public IFormFile Image { get; set; }
    }
}
