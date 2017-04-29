using EventManagement.DataModels.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.DataModels
{
    public class PurchaseDTO
    {
        public int ConferenceId { get; set; }

        [Required(ErrorMessage = "Your must provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Your must provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Your must provide a Organization")]
        public string Organization { get; set; }
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Your must provide a EmailId")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Your must select a Country")]
        public int CountryId { get; set; }
        [Display(Name = "Interested In")]
        public int RegTypeId { get; set; }
        [Display(Name = "Organisation Type")]
        public int RegClassId { get; set; }
        [Display(Name = "Accommodation")]
        public int AccId { get; set; }
        [Display(Name = "Occupancy for")]
        public int OccId { get; set; }
        [Display(Name = "Accompaning Persons")]
        public int AccompanyId { get; set; }
        public int Amount { get; set; }

        [Display(Name = "Accept Terms and Conditions")]
        [MustBeTrue(ErrorMessage = "Terms and Conditions havent been accepted")]
        public bool TermsAndConditions { get; set; }
        public IEnumerable<RegistrationTypeDTO> Reg { get; set; }
        public IEnumerable<AccommodationDTO> acc { get; set; }
    }
}
