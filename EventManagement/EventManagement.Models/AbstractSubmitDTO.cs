using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EventManagement.DataModels
{
    public class AbstractSubmitDTO
    {

        [Display(Name= "Name")]
        public string SubmittedBy { get; set; }
        [Display(Name= "Email Id")]
        [Required(ErrorMessage = "Your must provide a EmailId")]
        public string EmailId { get; set; }
        public string Organisation { get; set; }
        [Display(Name="Upload Abstract")]
        public HttpPostedFileBase DocUpload { get; set; }
        public string DocUrl { get; set; }
        [Display(Name="Interested In")]
        public int Category { get; set; }
        [Display(Name="Sessions")]
        public int Track { get; set; }
        public int Country { get; set; }
        public int Title { get; set; }
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public int Telephone { get; set; }
        public int ConferenceId { get; set; }

    }
}
