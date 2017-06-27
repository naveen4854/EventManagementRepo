using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class MediaPartnersDTO
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string WebUrl { get; set; }
        public string Title { get; set; }
        public string MediaName { get; set; }
        public string ImgSrc { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
