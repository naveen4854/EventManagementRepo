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
        public List<ConferenceDTO> getConference() {
            return c.getConference();
        }
    }
}
