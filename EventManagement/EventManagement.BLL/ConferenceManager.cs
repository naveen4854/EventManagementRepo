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

        public string GetNextConference()
        {
            var conferences = confOperations.GetConferences().OrderBy(q => q.StartDt);
            return conferences.FirstOrDefault(q => DateTime.Compare(q.StartDt, DateTime.Now.Date) >= 0).DisplayId;
        }

        public List<ConferenceDTO> GetConferences()
        {
            return confOperations.GetConferences();
        }

        public PurchaseDTO GetRegistrationDetails(int regId)
        {
            return confOperations.GetRegistrationDetails(regId);
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

        public void AddCountry(CountryModel country)
        {
            confOperations.AddCountry(country);
        }

        public int GetConferenceId(string key)
        {
            return confOperations.GetConferenceId(key);
        }

        public IEnumerable<RegistrationTypeDTO> GetConferencePrices(int id, IEnumerable<RegistrationClass> regclass)
        {
            var priceList = confOperations.GetConferencePrices(id).ToList();
            priceList.ForEach(q =>
            {
                q.PricingTypes.ToList().ForEach(
                    x =>
                    {
                        x.IsActive = regclass.FirstOrDefault(y => y.Id == x.RegClassId).IsActive;
                    });
            });


            return priceList;
        }

        public IEnumerable<RegistrationClass> GetConferenceRegClassMapping(int id)
        {
            var c = confOperations.GetConferenceRegClassMapping(id).ToList();
            c.ForEach(q =>
            {
                if (q.FromDt == null)
                    q.Name = q.Name + " Registration [split] On/Before " + q.ToDt.GetValueOrDefault().ToString("MMMM dd,yyyy");
                else if (q.ToDt == null)
                    q.Name = q.Name + " Registration [split] After " + q.FromDt.GetValueOrDefault().ToString("MMMM dd,yyyy");
                else
                    q.Name = q.Name + " Registration [split] From " + q.FromDt.GetValueOrDefault().ToString("MMMM dd,yyyy") + " To " + q.ToDt.GetValueOrDefault().ToString("MMMM dd,yyyy");

                q.IsActive = DateTime.Compare(DateTime.Now, q.FromDt ?? DateTime.Now) >= 0 && DateTime.Compare(DateTime.Now, q.ToDt ?? DateTime.Now) <= 0;
            });
            return c;
        }

        public ConferenceDTO GetConference(int id)
        {
            return confOperations.GetConference(id);
        }

        public bool AddConference(ConferenceDTO obj)
        {
            if (obj.ShortImageUpload != null)
                obj.ShortImgUrl = _uploadHelper.UploadFile(obj.ShortImageUpload, "~/content/images/event/confShortImage/");
            return confOperations.AddConference(obj);
        }

        public ConferenceDTO GetConferenceTeam(int id)
        {
            var conf = confOperations.GetConferenceTeam(id);
            foreach (var team in conf.Team)
            {
                team.ImageUrl = Utilities.ProcessDefaultImage(team.ImageUrl, "~/Content/images/confteam/");
            }
            return conf;
        }

        public ConferenceDTO GetAllConferenceTeam(int id)
        {
            return confOperations.GetAllConferenceTeam(id);
        }

        public ConferenceDTO GetConferenceChair(int id)
        {
            return confOperations.GetConferenceChair(id);
        }

        public bool AddTrack(TrackDTO obj)
        {
            return confOperations.AddTrack(obj);
        }

        public List<ProgramDTO> GetConferencePrograms(int id, int day)
        {
            var conf = confOperations.GetConferencePeriod(id);
            var prglst = confOperations.GetProgramsByConf(id).Where(q => q.ProgramDt.Date == conf.StartDt.AddDays(day).Date).ToList();
            foreach (var prg in prglst)
            {
                prg.ImageUrl = Utilities.ProcessDefaultImage(prg.ImageUrl, "~/Content/images/confprog/");
            }
            return prglst;
        }

        public IEnumerable<ProgramDTO> GetConferencePosters(int id)
        {
            return confOperations.GetPostersByConf(id);
        }

        public bool UpdateConference(ConferenceDTO obj)
        {
            if (obj.ShortImageUpload != null)
                obj.ShortImgUrl = _uploadHelper.UploadFile(obj.ShortImageUpload, "~/content/images/event/confShortImage/");
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
                var fileName = "";
                if (image != null)
                    fileName = _uploadHelper.UploadFile(image, "~/content/images");
                confOperations.PostConferenceImage(new ConferenceImageDTO { Name = fileName, ConferenceId = obj.Id });
            }
        }

        public void AddConferenceTeam(TeamMemberDTO obj)
        {
            if (obj.ImageUpload != null)
                obj.ImageUrl = _uploadHelper.UploadFile(obj.ImageUpload, "~/content/images/confteam");
            confOperations.AddConferenceTeam(obj);
        }

        public object GetTrack(int id)
        {
            return confOperations.GetTrack(id);
        }

        public string GetConferenceBrochure(int id)
        {
            return confOperations.GetConferenceBrochure(id);
        }

        public bool UpdateTrack(TrackDTO obj)
        {
            return confOperations.UpdateTrack(obj);
        }

        public ConferenceDTO GetConferenceImages(int id)
        {
            return new ConferenceDTO { Id = id, ImageUrls = confOperations.GetConferenceImages(id) };
        }

        public IEnumerable<ConferenceImageDTO> GetConferenceImagesDTO(int id)
        {
            return confOperations.GetConferenceImagesDTO(id);
        }

        public bool DeleteTrack(int id)
        {
            return confOperations.DeleteTrack(id);
        }

        public object UpdateTrack(int conferenceId)
        {
            throw new NotImplementedException();
        }

        public string GetAbstract(int id, int prgId)
        {
            return confOperations.GetAbstract(id, prgId);
        }

        public List<TrackDTO> GetConferenceTracks(int id)
        {
            return confOperations.GetConferenceTracks(id);
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

        public bool SubmitAbstract(AbstractSubmitDTO obj)
        {
            if (obj.DocUpload != null)
                obj.DocUrl = _uploadHelper.UploadFile(obj.DocUpload, "~/content/uploads/");

            var id = confOperations.SubmitAbstract(obj);

            var confEmail = confOperations.GetConferenceEmailId(obj.ConferenceId);

            var _track = confOperations.GetTrack(obj.Track);
            var _country = confOperations.GetCountry(obj.Country);
            var _category = confOperations.GetCategory(obj.Category);

            var mailData = new List<MailData>();
            mailData.Add(new MailData { Placeholder = "{NAME}", Data = obj.SubmittedBy });
            mailData.Add(new MailData { Placeholder = "{EMAIL}", Data = obj.EmailId });
            mailData.Add(new MailData { Placeholder = "{COUNTRY}", Data = _country });
            mailData.Add(new MailData { Placeholder = "{TELEPHONE}", Data = obj.Telephone.ToString() });
            mailData.Add(new MailData { Placeholder = "{TRACK}", Data = _track.Name });
            mailData.Add(new MailData { Placeholder = "{INTEREST}", Data = _category });

            if (!string.IsNullOrEmpty(obj.DocUrl))
                _mailHelper.SendMailWithAttachment(confEmail, obj.EmailId, obj.DocUrl, "Abstract Submission", "AbstractSubmitter", mailData);

            if (!string.IsNullOrEmpty(obj.DocUrl))
                _mailHelper.SendMailWithAttachment("sc_admin@scientificcognizance.com", confEmail, obj.DocUrl, "Abstract Submission", "AbstractReciever", mailData);

            return true;
        }

        public List<ProgramDTO> GetAllConferencePrograms(int conferenceId)
        {
            return confOperations.GetProgramsByConf(conferenceId).ToList();
        }

        public bool AddConferenceProgram(ProgramDTO obj)
        {
            if (obj.ImageUpload != null)
                obj.ImageUrl = _uploadHelper.UploadFile(obj.ImageUpload, "~/Content/images/confprog/");

            return confOperations.AddProgram(obj);
        }

        public int GetRegPrice(int regTypeId, int regClassId, int confId)
        {
            return confOperations.GetRegPrice(regTypeId, regClassId, confId);
        }

        public string GetConferenceKey(int conferenceId)
        {
            return confOperations.GetConferenceKey(conferenceId);
        }

        public bool DeleteConferenceImage(int id)
        {
            return confOperations.DeleteConferenceImage(id);
        }

        public int GetAccPrice(int accTypeId, int occId, int confId)
        {
            return confOperations.GetAccPrice(accTypeId, occId, confId);
        }

        public IEnumerable<AccompanyPriceDTO> GetAllAccompanyPrice(int id)
        {
            return confOperations.GetAllAccompanyPrice(id);
        }

        public int GetAccompanyPrice(int accompanyId, int confId)
        {
            return confOperations.GetAccompanyPrice(accompanyId, confId);
        }

        public TeamMemberDTO GetTeamMember(int id)
        {
            return confOperations.GetTeamMember(id);
        }

        public bool UpdateTeamMember(TeamMemberDTO obj)
        {
            if (obj.ImageUpload != null)
                obj.ImageUrl = _uploadHelper.UploadFile(obj.ImageUpload, "~/content/images/confteam");
            return confOperations.UpdateTeamMember(obj);
        }

        public IEnumerable<MemberTypeDTO> GetMemberTypes()
        {
            return confOperations.GetMemberTypes();
        }

        public TeamMemberDTO DeleteTeamMember(int id)
        {
            return confOperations.DeleteTeamMember(id);
        }

        public IEnumerable<ProgramDTO> GetAllProgramsByConf(int conferenceId)
        {
            return confOperations.GetProgramsByConf(conferenceId).ToList();
        }

        public bool AddProgram(ProgramDTO obj)
        {
            if (obj.ImageUpload != null)
                obj.ImageUrl = _uploadHelper.UploadFile(obj.ImageUpload, "~/Content/images/confprog/");
            return confOperations.AddProgram(obj);
        }

        public object GetProgram(int id)
        {
            return confOperations.GetProgram(id);
        }

        public IEnumerable<TeamMemberDTO> GetSientificAdvisors()
        {
            var SAlst = confOperations.GetScientificAdvisors();
            foreach (var sa in SAlst)
            {
                sa.ImageUrl = Utilities.ProcessDefaultImage(sa.ImageUrl, "~/Content/images/confteam/");
            }
            return SAlst;
        }

        public bool UpdateProgram(ProgramDTO obj)
        {
            if (obj.ImageUpload != null)
                obj.ImageUrl = _uploadHelper.UploadFile(obj.ImageUpload, "~/Content/images/confprog/");
            return confOperations.UpdateProgram(obj);
        }

        public ProgramDTO DeleteProgram(int id)
        {
            return confOperations.DeleteProgram(id);
        }

        public string GetConferenceEmail(int id)
        {
            return confOperations.GetConferenceEmailId(id);
        }

        public int RegisterForConference(PurchaseDTO obj)
        {
            return confOperations.RegisterForConference(obj);
        }
    }
}
