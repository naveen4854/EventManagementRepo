using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class ConferenceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<ConferenceTeamDTO> team { get; set; }
    }
}
