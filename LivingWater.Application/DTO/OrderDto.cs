﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Application.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Date { get; set; }
        public CustomerDto Customer { get; set; }
        public WaterDto Water { get; set; }
    }
}
