using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DataModels
{
    public class ProgramDTO
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Abstract { get; set; }
        public DateTime ProgramDt { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
