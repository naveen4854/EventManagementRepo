﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class PricingType
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int RegClassId { get; set; }
    }
}
