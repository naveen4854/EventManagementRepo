using EventManagement.DAL.Models;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DAL.Operations
{
    public class ConferenceOperations
    {
        private EventManagementEntities managementConsoleEntities = new EventManagementEntities();
        public List<ConferenceDTO> getConference() {
            return managementConsoleEntities.Conferences.Select(q => new ConferenceDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                ShortDesc = q.ShortDescription
            }).ToList();
        }
    }
}
