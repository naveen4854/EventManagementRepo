﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class RegistrationViewModel
    {
        [Display(Name ="Id")]
        public int RegId { get; set; }
        public string ConferenceName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Country { get; set; }
        public double Amount { get; set; }
        [Display(Name ="Status")]
        public string RegStatus { get; set; }
        [Display(Name ="Date")]
        public DateTime RegDateTime { get; set; }
    }
}
