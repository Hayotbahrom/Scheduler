using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Data.Repositories;
using BeautyScheduler.Service.Interfaces;
using BeautyScheduler.Service.Services;

namespace BeautyScheduler.Api.Extentions;

public static class ServiceExtentions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        // registered repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IServiceStaffRepository, ServiceStaffRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();

        // registered services
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IServiceCustomerService, ServiceCustomerService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IServiceStaffService, ServiceStaffService>();
        services.AddScoped<IFileUploadService, FileUploadService>();
    }

}
