﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Service.DTOs.Service
{
    public class ServiceCreationDto
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public long Duration { get; set; }
        public decimal Price { get; set; }
    }
}
