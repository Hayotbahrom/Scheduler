using BeautyScheduler.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Data.DbContexts
{
    public class BeautySchedulerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCustomer> CustomerServices { get; set; }
        public DbSet<ServiceStaff> StaffServices { get; set; }

        public BeautySchedulerDbContext(DbContextOptions<BeautySchedulerDbContext> options) : base(options)
        {

        }
    }

}
