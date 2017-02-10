using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.DataModels
{
    public class PurchaseDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<RegistrationDTO> Reg { get; set; }
    }
}
