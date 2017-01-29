using System.Web;

namespace EventManagement.DataModels
{
    public class AbstractSubmitDTO
    {

        public string SubmittedBy { get; set; }
        public string EmailId { get; set; }
        public string Organisation { get; set; }
        public HttpPostedFileBase DocUpload { get; set; }
        public string DocUrl { get; set; }
        public int Category { get; set; }
        public int Track { get; set; }
        public int Country { get; set; }
        public int Title { get; set; }
        public int Telephone { get; set; }
        public int ConferenceId { get; set; }

    }
}
