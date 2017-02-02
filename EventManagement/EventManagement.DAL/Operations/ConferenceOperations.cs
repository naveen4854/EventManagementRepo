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

        public List<VenueDTO> GetVenues()
        {
            return managementConsoleEntities.Venues.Select(q => new VenueDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
            }).ToList();
        }

        public bool AddVenue(VenueDTO obj)
        {
            var a = new Venue
            {
                Name = obj.Name,
                Description = obj.Desc,
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Venues.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public bool AddConference(ConferenceDTO obj)
        {
            var a = new Conference
            {
                Name = obj.Name,
                Description = obj.Desc,
                ShortDescription = obj.ShortDesc,
                FK_VenueId = obj.Venue.Id,
                startDt = DateTime.Now,
                endDt = DateTime.Now.AddDays(5)
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Conferences.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public bool AddTrack(TrackDTO obj)
        {
            var a = new Track
            {
                Name = obj.Name,
                Description = obj.Desc,
                FK_ConferenceId = obj.ConferenceId
            };
            using (var entities = new EventManagementEntities())
            {
                entities.Tracks.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public List<string> GetConferenceImages(int id)
        {
            return managementConsoleEntities.ConferenceImages.Where(q => q.FK_ConferenceId == id).Select(q => q.ImageUrl).ToList();
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
                ImageUrls = conf.ConferenceImages.Select(q => q.ImageUrl).ToList(),
                Venue = new VenueDTO
                {
                    Id = conf.Venue.Id,
                    Name = conf.Venue.Name,
                    Desc = conf.Venue.Description
                }
            };
        }

        public bool AddConferenceTeam(ConferenceTeamDTO obj)
        {
            var a = new ConferenceTeam
            {
                Name = obj.Name,
                Biography = obj.Biography,
                Chair = obj.isChair,
                ImageUrl = obj.ImageUrl,
                Info = obj.Info,
                FK_ConferenceId = obj.ConferenceId
            };
            using (var entities = new EventManagementEntities())
            {
                entities.ConferenceTeams.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public bool PostConferenceImage(ConferenceImageModel conferenceImage)
        {
            var a = new ConferenceImage
            {
                ImageUrl = conferenceImage.Name,
                FK_ConferenceId = conferenceImage.ConferenceId
            };
            using (var entities = new EventManagementEntities())
            {
                entities.ConferenceImages.Add(a);
                entities.SaveChanges();
            }
            return true;
        }

        public List<ProgramDTO> GetConferencePrograms(int id)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id).Select(q => new ProgramDTO
            {
                Id = q.Id,
                Name = q.Name,
                ImageUrl = q.ImageUrl,
                Info = q.Info,
                ProgramDt = q.ProgramDt,
                Title = q.Title
            }).ToList();
        }

        public List<TrackDTO> GetTracks(int id)
        {
            return managementConsoleEntities.Tracks.Where(q => q.FK_ConferenceId == id).Select(q => new TrackDTO
            {
                Id = q.Id,
                Name = q.Name,
                Desc = q.Description,
                ConferenceId = q.FK_ConferenceId
            }).ToList();
        }

        public string GetAbstract(int id, int prgId)
        {
            return managementConsoleEntities.Programs.Where(q => q.FK_ConferenceId == id && q.Id == prgId).Select(q=>q.Abstract).FirstOrDefault();
        }

        public int PostAbstract(AbstractSubmitDTO obj)
        {
            var a = new AbstractsSubmitted
            {
                SubmittedBy = obj.SubmittedBy,
                EmailId = obj.EmailId,
                FK_CategoryId = obj.Category,
                FK_ContryId = obj.Country,
                DocName = obj.DocUrl,
                Organisation = obj.Organisation,
                FK_TrackID = obj.Track,
                FK_TitleId = obj.Title,
                FK_ConferenceId = obj.ConferenceId,
            };
            var id = -1;
            using (var entities = new EventManagementEntities()) {
                entities.AbstractsSubmitteds.Add(a);
                entities.SaveChanges();
                id = a.Id; 
            }
            return id;
        }

        public string GetConferenceBrochure(int id)
        {
            return managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == id).brochure;
        }

        public ConferenceDTO GetConferencePeriod(int id)
        {
            var conf = managementConsoleEntities.Conferences.FirstOrDefault(q => q.Id == id);
            return new ConferenceDTO
            {
                Id = conf.Id,
                StartDt = conf.startDt,
                EndDt = conf.endDt
            };
        }

        public ConferenceDTO GetConferenceTeam(int id)
        {
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && !q.Chair).Select(q=>new ConferenceTeamDTO {
                ConferenceId = q.FK_ConferenceId,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl
            }).ToList();
            return new ConferenceDTO
            {
                Team = conf
            };
        }

        public ConferenceDTO GetConferenceChair(int id)
        {
            var conf = managementConsoleEntities.ConferenceTeams.Where(q => q.FK_ConferenceId == id && q.Chair).Select(q => new ConferenceTeamDTO
            {
                ConferenceId = q.FK_ConferenceId,
                Name = q.Name,
                Info = q.Info,
                isChair = q.Chair,
                Biography = q.Biography,
                ImageUrl = q.ImageUrl
            }).ToList();
            return new ConferenceDTO
            {
                Team = conf
            };
        }

        public List<CountryModel> GetCountries()
        {
            return managementConsoleEntities.Countries.Select(q => new CountryModel
            {
                Id = q.Id,
                Name = q.Name,
            }).ToList();
        }

        public List<CategoryModel> GetCategories()
        {
            return managementConsoleEntities.Categories.Select(q => new CategoryModel
            {
                Id = q.Id,
                Name = q.Name,
            }).ToList();
        }

        public List<TitleModel> GetTitles()
        {
            return managementConsoleEntities.Titles.Select(q => new TitleModel
            {
                Id = q.Id,
                Name = q.Name,
            }).ToList();
        }
    }
}
