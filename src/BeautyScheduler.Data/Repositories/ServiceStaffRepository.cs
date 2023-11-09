﻿using BeautyScheduler.Data.DbContexts;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Data.Repositories
{
    public class ServiceStaffRepository : Repository<ServiceStaff>, IServiceStaffRepository
    {
        public ServiceStaffRepository(BeautySchedulerDbContext beautySchedulerDbContext) : base(beautySchedulerDbContext)
        {
        }
    }
}
