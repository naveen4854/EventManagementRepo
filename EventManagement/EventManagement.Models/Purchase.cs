using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Purchase
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpriationYear { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
