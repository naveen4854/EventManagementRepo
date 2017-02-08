using System;
using System.Web;
using EventManagement.DAL.Operations;
using EventManagement.DataModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EventManagement.BLL.Helpers;

namespace EventManagement.BLL
{
    public class ConferenceManager
    {
        private ConferenceOperations confOperations;
        private MailHelper _mailHelper;
        private UploadHelper _uploadHelper;
        public ConferenceManager()
        {
            confOperations = new ConferenceOperations();
            _mailHelper = new MailHelper();
            _uploadHelper = new UploadHelper();
        }
        public List<ConferenceDTO> GetConferences()
        {
            return confOperations.GetConferences();
        }

        public VenueDTO GetVenue(int id)
        {
            return confOperations.GetVenue(id);
        }

        public bool UpdateVenue(VenueDTO id)
        {
            return confOperations.UpdateVenue(id);
        }

        public bool AddVenue(VenueDTO obj)
        {
            return confOperations.AddVenue(obj);
        }

        public List<VenueDTO> GetVenues()
        {
            return confOperations.GetVenues();
        }

        public bool DeleteVenue(int id)
        {
            return confOperations.DeleteVenue(id);
        }

        public ConferenceDTO GetConference(int id)
        {
            return confOperations.GetConference(id);
        }

        public bool AddConference(ConferenceDTO obj)
        {
            return confOperations.AddConference(obj);
        }

        public ConferenceDTO GetConferenceTeam(int id)
        {
            return confOperations.GetConferenceTeam(id);
        }

        public ConferenceDTO GetConferenceChair(int id)
        {
            return confOperations.GetConferenceChair(id);
        }

        public int AddTrack(TrackDTO obj)
        {
            return confOperations.AddTrack(obj);
        }

        public List<ProgramDTO> GetConferencePrograms(int id, int day)
        {
            var conf = confOperations.GetConferencePeriod(id);
            return confOperations.GetConferencePrograms(id).Where(q => q.ProgramDt.Date == conf.StartDt.AddDays(day).Date).ToList();
        }

        public bool UpdateConference(ConferenceDTO obj)
        {
            return confOperations.UpdateConference(obj);
        }

        public bool DeleteConference(int id)
        {
            return confOperations.DeleteConference(id);
        }

        public ConferenceDTO GetConferencePeriod(int id)
        {
            return confOperations.GetConferencePeriod(id);
        }

        public void AddConferenceImages(ConferenceDTO obj)
        {
            foreach (var image in obj.ImagesUpload)
            {
                var fileName = _uploadHelper.UploadFile(image, "~/content/images");
                confOperations.PostConferenceImage(new ConferenceImageModel { Name = fileName, ConferenceId = obj.Id });
            }
        }

        public TrackDTO GetTrack(int id)
        {
            return confOperations.GetTrack(id);
        }

        public void AddConferenceTeam(ConferenceTeamDTO obj)
        {
            obj.ImageUrl = _uploadHelper.UploadFile(obj.ImageUpload, "~/content/images/confteam");
            confOperations.AddConferenceTeam(obj);
        }

        public string GetConferenceBrochure(int id)
        {
            return confOperations.GetConferenceBrochure(id);
        }

        public bool UpdateTrack(TrackDTO obj)
        {
            return confOperations.UpdateTrack(obj);
        }

        public TrackDTO DeleteTrack(int id)
        {
            return confOperations.DeleteTrack(id);
        }

        public ConferenceDTO GetConferenceImages(int id)
        {
            return new ConferenceDTO { Id = id, ImageUrls = confOperations.GetConferenceImages(id) };
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

        public bool PostAbstract(AbstractSubmitDTO obj)
        {
            var fileName = Guid.NewGuid() + "_" + obj.DocUpload.FileName;

            if (obj.DocUpload != null && obj.DocUpload.ContentLength > 0)
            {
                var uploadDir = "~/content/uploads/";
                var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(uploadDir), fileName);
                obj.DocUpload.SaveAs(filePath);
            }
            obj.DocUrl = fileName;
            var id = confOperations.PostAbstract(obj);

            _mailHelper.SendMailWithAttachment("sc_admin@scientificcognizance.com", obj.EmailId, fileName);

            return true;
        }

        public List<ProgramDTO> GetAllConferencePrograms(int conferenceId)
        {
            var conf = confOperations.GetConferencePeriod(conferenceId);
            return confOperations.GetConferencePrograms(conferenceId).ToList();
        }

        public bool AddConferenceProgram(ProgramDTO obj)
        {
            return confOperations.AddProgram(obj);
        }
    }
}
