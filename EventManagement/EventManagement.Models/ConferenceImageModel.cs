using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DataModels
{
    public class ConferenceImageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ConferenceId { get; set; }
        public HttpPostedFileBase ImagesUpload { get; set; }
    }
}
