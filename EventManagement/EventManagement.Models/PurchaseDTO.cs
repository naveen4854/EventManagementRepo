using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.DataModels
{
    public class PurchaseDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Organization { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailId { get; set; }
        [Display(Name="Country")]
        public int CountryId { get; set; }
        [Display(Name="Interested In")]
        public int RegTypeId { get; set; }
        [Display(Name="Organisation Type")]
        public int RegClassId { get; set; }
        [Display(Name="Accommodation")]
        public int AccId { get; set; }
        [Display(Name="Occupancy for")]
        public int OccId { get; set; }
        [Display(Name="Accompaning Persons")]
        public int AccompanyId { get; set; }
        public int Amount { get; set; }
        public IEnumerable<RegistrationDTO> Reg { get; set; }
        public IEnumerable<AccommodationDTO> acc { get; set; }
    }
}
