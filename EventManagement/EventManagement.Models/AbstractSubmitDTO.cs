using EventManagement.DataModels.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EventManagement.DataModels
{
    public class AbstractSubmitDTO
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must provide a Name")]
        public string SubmittedBy { get; set; }
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "You must provide a EmailId")]
        public string EmailId { get; set; }
        public string Organisation { get; set; }
        [Display(Name = "Upload Abstract")]
        [Required(ErrorMessage = "You must Select a File")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} bytes")]
        [FileType("DOC,DOCX,PDF")]
        //[FileExtensions(Extensions = "doc,docx,pdf", ErrorMessage = "Please upload valid file(doc,docx,pdf)")]
        public HttpPostedFileBase DocUpload { get; set; }
        public string DocUrl { get; set; }
        [Display(Name = "Interested In")]
        [Required(ErrorMessage = "You must Select Interest")]
        public int Category { get; set; }
        [Display(Name = "Sessions")]
        [Required(ErrorMessage = "You must Select a Session")]
        public int Track { get; set; }
        [Required(ErrorMessage = "You must Select a Country")]
        public int Country { get; set; }
        public int Title { get; set; }
        [Required(ErrorMessage = "You must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Telephone { get; set; }
        public int ConferenceId { get; set; }

    }
}
