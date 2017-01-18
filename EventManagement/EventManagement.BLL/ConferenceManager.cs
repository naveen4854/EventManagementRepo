using EventManagement.DAL.Operations;
using EventManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BLL
{
    public class ConferenceManager
    {
        private ConferenceOperations c;
        public ConferenceManager() {
            c = new ConferenceOperations();
        }
        public List<ConferenceDTO> GetConferences() {
            return c.GetConferences();
        }

        public ConferenceDTO GetConference(int id)
        {
            return c.GetConference(id);
        }
    }
}
