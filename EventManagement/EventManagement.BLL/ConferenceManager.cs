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

        public ConferenceDTO GetConferenceChair(int id)
        {
            return c.GetConferenceChair(id);
        }

        public List<ProgramDTO> GetConferencePrograms(int id,int day)
        {
            var conf = c.GetConferencePeriod(id);
            return c.GetConferencePrograms(id).Where(q => q.ProgramDt.Date == conf.StartDt.AddDays(day).Date).ToList();
        }

        public ConferenceDTO GetConferencePeriod(int id)
        {
            return c.GetConferencePeriod(id);
        }
    }
}
