using AutoMapper;
using BeautyScheduler.Domain.Entites;
using BeautyScheduler.Service.DTOs.Customer;
using BeautyScheduler.Service.DTOs.CustomerService;
using BeautyScheduler.Service.DTOs.Payment;
using BeautyScheduler.Service.DTOs.Service;
using BeautyScheduler.Service.DTOs.Staff;
using BeautyScheduler.Service.DTOs.StaffService;
using BeautyScheduler.Service.Services;

namespace BeautyScheduler.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer
            CreateMap<Customer, CustomerCreationDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
            CreateMap<Customer, CustomerResultDto>().ReverseMap();

            // Staff
            CreateMap<Staff, StaffCreationDto>().ReverseMap();
            CreateMap<Staff, StaffUpdateDto>().ReverseMap();
            CreateMap<Staff, StaffResultDto>().ReverseMap();

            // Payment
            CreateMap<Payment, PaymentCreationDto>().ReverseMap();
            CreateMap<Payment, PaymentUpdateDto>().ReverseMap();
            CreateMap<Payment, PaymentResultDto>().ReverseMap();

            //Service
            CreateMap<Domain.Entites.Service, ServiceCreationDto>().ReverseMap();
            CreateMap<Domain.Entites.Service, ServiceUpdateDto>().ReverseMap();
            CreateMap<Domain.Entites.Service, ServiceResultDto>().ReverseMap();

            // ServiceStaff
            CreateMap<ServiceStaff, StaffServiceCreationDto>().ReverseMap();
            CreateMap<ServiceStaff, StaffServiceUpdateDto>().ReverseMap();
            CreateMap<ServiceStaff, StaffServiceResultDto>().ReverseMap();

            // ServiceCustomer
            CreateMap<ServiceCustomer,CustomerServiceCreationDto>().ReverseMap();
            CreateMap<ServiceCustomer, CustomerServiceUpdateDto>().ReverseMap();
            CreateMap<ServiceCustomer, CustomerServiceResultDto>().ReverseMap();
        }
    }
}
