using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventManagement.DataModels
{
    public class TeamMemberDTO
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool isChair { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}
