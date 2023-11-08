using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.CustomerService
{
    public class CustomerServiceResultDto
    {
        public CustomerCreationDto Customer {  get; set; }
        public ServiceResultDto Service {  get; set; }
    }
}
