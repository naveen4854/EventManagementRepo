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

        public ConferenceDTO GetConferenceTeam(int id)
        {
            return c.GetConferenceTeam(id);
        }

        public object GetConferenceChair(int id)
        {
            return c.GetConferenceChair(id);
        }

        public object GetConferenceProgram(int id)
        {
            return c.GetConferenceProgram(id);
        }
    }
}
