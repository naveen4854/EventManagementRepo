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
        private ConferenceOperations confOperations;
        public ConferenceManager() {
            confOperations = new ConferenceOperations();
        }
        public List<ConferenceDTO> GetConferences() {
            return confOperations.GetConferences();
        }

        public ConferenceDTO GetConference(int id)
        {
            return confOperations.GetConference(id);
        }

        public ConferenceDTO GetConferenceTeam(int id)
        {
            return confOperations.GetConferenceTeam(id);
        }

        public ConferenceDTO GetConferenceChair(int id)
        {
            return confOperations.GetConferenceChair(id);
        }

        public List<ProgramDTO> GetConferencePrograms(int id,int day)
        {
            var conf = confOperations.GetConferencePeriod(id);
            return confOperations.GetConferencePrograms(id).Where(q => q.ProgramDt.Date == conf.StartDt.AddDays(day).Date).ToList();
        }

        public ConferenceDTO GetConferencePeriod(int id)
        {
            return confOperations.GetConferencePeriod(id);
        }

        public string GetConferenceBrochure(int id)
        {
            return confOperations.GetConferenceBrochure(id);
        }

        public string GetAbstract(int id, int prgId)
        {
            return confOperations.GetAbstract(id, prgId);
        }

        public List<TrackDTO> GetConferenceTracks(int id)
        {
            return confOperations.GetTracks(id);
        }

        public List<CategoryModel> GetCategories()
        {
            return confOperations.GetCategories();
        }

        public List<CountryModel> GetCountries()
        {
            return confOperations.GetCountries();
        }

        public List<TitleModel> GetTitles()
        {
            return confOperations.GetTitles();
        }

        public bool PostAbstractSubmit(AbstractSubmitDTO obj)
        {
            return confOperations.PostAbstractSubmit(obj);
        }
    }
}
