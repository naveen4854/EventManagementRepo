﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] CallingCodes { get; set; }
        public string CallingCode { get; set; }
    }
}
