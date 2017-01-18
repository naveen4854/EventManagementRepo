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
        public List<ConferenceDTO> GetConferences() {
            return managementConsoleEntities.Conferences.Select(q => new ConferenceDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                ShortDesc = q.ShortDescription
            }).ToList();
        }

        public ConferenceDTO GetConference(int Id)
        {
            var conf = managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == Id);
            return new ConferenceDTO
            {
                Id = conf.Id,
                Name = conf.Name,
                Desc = conf.Description,
                ShortDesc = conf.ShortDescription,
                ImageUrls = conf.ConferenceImages.Select(q => q.ImageUrl).ToList()
            };
        }
    }
}
