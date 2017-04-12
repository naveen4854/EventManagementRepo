using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DataModels
{
    public class ConferenceDTO
    {
        public int Id { get; set; }
        [Display(Name = "Conference Name")]
        public string Name { get; set; }

        [Display(Name = "Conference URL")]
        public string DisplayId { get; set; }

        [Display(Name = "Description")]
        public string Desc { get; set; }
        [Display(Name = "Theme")]
        public string ShortDesc { get; set; }

        [Display(Name = "Conference Email")]
        public string ConfEmail { get; set; }
        public string ShortImgUrl { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDt { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDt { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<TeamMemberDTO> Team { get; set; }
        public VenueDTO Venue { get; set; }
        public List<ProgramDTO> Programs { get; set; }
        public IEnumerable<HttpPostedFileBase> ImagesUpload { get; set; }
        [Display(Name = "Short Image")]
        public HttpPostedFileBase ShortImageUpload { get; set; }

    }
}
