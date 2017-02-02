using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DataModels
{
    public class ConferenceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<ConferenceTeamDTO> Team { get; set; }
        public VenueDTO Venue { get; set; }
        public List<ProgramDTO> Programs { get; set; }
        public IEnumerable<HttpPostedFileBase> ImagesUpload { get; set; }
    }
}
